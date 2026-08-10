using System;

namespace CsharpFundamentals.ObjectOrientedProgramming
{
    internal class Interfaces
    {
        public static void Run()
        {
            // ============================================
            // Computer implements IDevice and IRestartable
            // ============================================

            // The reference type is IDevice,
            // but the actual object is a Computer.
            IDevice device1 = new Computer();

            device1.TurnOn();
            device1.TurnOff();

            // IRestartable methods are not available through
            // an IDevice reference, so we cast to IRestartable.
            ((IRestartable)device1).Restart();

            // Calls the explicit IDevice.Stop() implementation.
            device1.Stop();

            // Calls the explicit IRestartable.Stop() implementation.
            ((IRestartable)device1).Stop();


            // ============================================
            // Phone implements IDevice and IRestartable
            // ============================================

            IDevice device2 = new Phone();

            device2.TurnOn();
            device2.TurnOff();

            // Cast IDevice to IRestartable to access Restart().
            ((IRestartable)device2).Restart();

            // Calls Phone's explicit IDevice.Stop().
            device2.Stop();


            // ============================================
            // Monitor implements only IDevice
            // ============================================

            IDevice device3 = new Monitor();

            device3.TurnOn();
            device3.TurnOff();

            // Calls Monitor's normal implementation of Stop().
            device3.Stop();


            // ============================================
            // Accessing the concrete Computer class
            // ============================================

            Computer device4 = new Computer();

            // Calls the normal public Stop() method.
            device4.Stop();

            // Access the default interface implementation.
            ((IDevice)device4).DefaultImplementation();

            // Static interface member.
            Console.WriteLine(IDevice.S);
        }
    }


    // =====================================================
    // INTERFACE
    // =====================================================

    // By convention, interface names start with "I".
    interface IDevice
    {
        // Before C# 8:
        // - Interface members were public by default.
        // - Interfaces could not contain method implementations.
        // - Interfaces could not contain instance fields.

        void TurnOn();
        void TurnOff();
        void Stop();


        // Since C# 8:
        // Interfaces can have default implementations.
        //
        // A class does NOT have to implement this method.
        public void DefaultImplementation()
        {
            Console.WriteLine("Default Implementation");
        }


        // Interfaces can have static fields.
        // This field belongs to the interface itself.
        public static int S = 10;
    }


    // =====================================================
    // SECOND INTERFACE
    // =====================================================

    // A class can implement multiple interfaces.
    interface IRestartable
    {
        void Restart();
        void Stop();
    }


    // =====================================================
    // COMPUTER
    // =====================================================

    // Computer implements two interfaces.
    class Computer : IDevice, IRestartable
    {
        // Implicit interface implementation.
        //
        // The interface name does not need to be specified.
        public void TurnOn()
        {
            Console.WriteLine("Computer Turn On");
        }

        public void TurnOff()
        {
            Console.WriteLine("Computer Turn Off");
        }

        public void Restart()
        {
            Console.WriteLine("Computer Restart");
        }


        // Explicit implementation of IDevice.Stop().
        //
        // This implementation is accessible only
        // through an IDevice reference.
        void IDevice.Stop()
        {
            Console.WriteLine("Computer IDevice Explicit Stop");
        }


        // Normal public method.
        //
        // This is accessible through a Computer reference.
        public void Stop()
        {
            Console.WriteLine("Computer Normal Stop");
        }


        // Explicit implementation of IRestartable.Stop().
        //
        // This is accessible only through an IRestartable reference.
        void IRestartable.Stop()
        {
            Console.WriteLine("Computer IRestartable Explicit Stop");
        }
    }


    // =====================================================
    // PHONE
    // =====================================================

    class Phone : IDevice, IRestartable
    {
        public void TurnOn()
        {
            Console.WriteLine("Phone Turn On");
        }

        public void TurnOff()
        {
            Console.WriteLine("Phone Turn Off");
        }

        public void Restart()
        {
            Console.WriteLine("Phone Restart");
        }


        // Explicit implementation for IDevice.Stop().
        void IDevice.Stop()
        {
            Console.WriteLine("Phone IDevice Explicit Stop");
        }


        // Explicit implementation for IRestartable.Stop().
        void IRestartable.Stop()
        {
            Console.WriteLine("Phone IRestartable Explicit Stop");
        }
    }


    // =====================================================
    // MONITOR
    // =====================================================

    // Monitor implements only IDevice.
    class Monitor : IDevice
    {
        public void TurnOn()
        {
            Console.WriteLine("Monitor Turn On");
        }

        public void TurnOff()
        {
            Console.WriteLine("Monitor Turn Off");
        }

        // Normal/implicit implementation of IDevice.Stop().
        public void Stop()
        {
            Console.WriteLine("Monitor IDevice Implicit Stop");
        }
    }
}