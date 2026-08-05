namespace CsharpFundamentals.CsharpOop;

internal static class ObjectLifetimeAndDisposal
{
    public static void Run()
    {
        Console.WriteLine("\n========== Object Lifetime and Disposal ==========");

        // using compiles to try/finally and calls Dispose even if an exception occurs.
        using (DemoResource resource = new("sync-resource"))
        {
            resource.Use();
        }

        // A using declaration disposes the object at the end of the current scope.
        using DemoResource scoped = new("scope-resource");
        scoped.Use();

        AsyncDisposalExample().GetAwaiter().GetResult();

        using NativeBuffer buffer = new(16);
        Console.WriteLine($"Native buffer size: {buffer.Size} bytes.");

        // The garbage collector manages memory, but Dispose manages scarce external resources promptly.
        // Never call GC.Collect in normal application code to solve resource ownership problems.
    }

    private sealed class DemoResource : IDisposable
    {
        private bool _disposed;
        private readonly string _name;

        public DemoResource(string name)
        {
            _name = name;
            Console.WriteLine($"Opened {_name}.");
        }

        public void Use()
        {
            ObjectDisposedException.ThrowIf(_disposed, this);
            Console.WriteLine($"Using {_name}.");
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            Console.WriteLine($"Closed {_name}.");
            _disposed = true;
        }
    }

    // Use IAsyncDisposable when cleanup itself requires asynchronous I/O.
    private sealed class AsyncDemoResource : IAsyncDisposable
    {
        public async ValueTask DisposeAsync()
        {
            await Task.Yield();
            Console.WriteLine("Asynchronous cleanup completed.");
        }
    }

    private static async Task AsyncDisposalExample()
    {
        // await using calls DisposeAsync when the scope ends.
        await using AsyncDemoResource resource = new();
        await Task.Yield();
    }

    private sealed class NativeBuffer : IDisposable
    {
        private IntPtr _pointer;

        public NativeBuffer(int size)
        {
            ArgumentOutOfRangeException.ThrowIfNegativeOrZero(size);
            Size = size;
            _pointer = System.Runtime.InteropServices.Marshal.AllocHGlobal(size);
        }

        public int Size { get; }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        // The finalizer is a safety net for directly owned unmanaged memory, not normal cleanup logic.
        ~NativeBuffer()
        {
            Dispose(disposing: false);
        }

        private void Dispose(bool disposing)
        {
            if (_pointer == IntPtr.Zero)
            {
                return;
            }

            // Managed resources would be released only when disposing is true.
            System.Runtime.InteropServices.Marshal.FreeHGlobal(_pointer);
            _pointer = IntPtr.Zero;
        }
    }

    // A finalizer is only appropriate when directly owning an unmanaged resource.
    // Prefer SafeHandle instead of writing a finalizer in most application code.
}
