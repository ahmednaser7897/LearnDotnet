namespace CsharpFundamentals.CsharpBasics
{
    internal class XmlDocumentation
    {
        public static void Run()
        {
            Console.WriteLine($"Main ID is {Genrator.LastId}");

            var id1 = Genrator.GenerateId("Ahmed", "Naser", DateTime.Now);
            var password1 = Genrator.GenerateRandomPassword(8);

            Console.WriteLine(
                $"Ahmed's ID is {id1} and his password is {password1}"
            );

            var id2 = Genrator.GenerateId("Mohamed", "Naser", DateTime.Now);
            var password2 = Genrator.GenerateRandomPassword(8);

            Console.WriteLine(
                $"Mohamed's ID is {id2} and his password is {password2}"
            );

            Console.WriteLine("==========================================");
            Console.WriteLine();
        }
    }

    /*
     * XML documentation is used to add descriptions to code members.
     *
     * Public members should be documented when creating reusable code.
     *
     * <summary>:
     * Used for a short description of a class, method, or property.
     *
     * To generate an XML documentation file:
     * Project -> Properties -> Build -> Documentation file.
     *
     * Choose a location for the generated XML file.
     *
     * We can also use an external XML file with <include>
     * instead of writing all XML documentation inside the C# file.
     */
    /*
    /// <summary>
    /// The main Generator class.
    /// </summary>
    /// <remarks>
    /// This class can generate IDs and passwords for new users.
    /// </remarks>
    /// 
    */
    /// // XML documentation is loaded from an external XML file.
    /// <include file='XmlFile.xml' path='doc/members/member[@name="T:CsharpFundamentals.CsharpBasics.Genrator"]/*'/>
    class Genrator
    {
        // XML documentation is loaded from an external XML file.
        /// <include file='XmlFile.xml' path='doc/members/member[@name="P:CsharpFundamentals.CsharpBasics.Genrator.LastId"]/*'/>
        public static int LastId { get; private set; } = 1;

        /*
         * The XML documentation for GenerateId was originally written here.
         *
         * It can also be moved to XmlFile.xml and loaded using <include>.
         */

        /*
        /// <summary>
        /// Used to generate an ID in this format: II YY MM DD SS.
        /// <list type="bullet">
        /// <item>II</item>
        /// <description>
        /// Initials: first letter of <paramref name="fname"/>
        /// and first letter of <paramref name="lname"/>.
        /// </description>
        /// <item>YY</item>
        /// <description>
        /// Year of <paramref name="hireDate"/>.
        /// </description>
        /// <item>MM</item>
        /// <description>
        /// Month of <paramref name="hireDate"/>.
        /// </description>
        /// <item>DD</item>
        /// <description>
        /// Day of <paramref name="hireDate"/>.
        /// </description>
        /// <item>SS</item>
        /// <description>
        /// The last value of <see cref="Genrator.LastId"/>.
        /// </description>
        /// </list>
        /// </summary>
        /// <param name="fname">Cannot be null or empty.</param>
        /// <param name="lname">Cannot be null or empty.</param>
        /// <param name="hireDate">
        /// If null, DateTime.Now will be used.
        /// </param>
        /// <example>
        /// var id = Genrator.GenerateId("Ahmed", "Naser", DateTime.Now);
        /// // AN 26 08 12 01
        /// </example>
        /// <returns>A generated ID as a string.</returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when <paramref name="fname"/> or
        /// <paramref name="lname"/> is null.
        /// </exception>
        /// <exception cref="Exception">
        /// Thrown when <paramref name="hireDate"/> is in the past.
        /// </exception>
        /// See <see cref="Genrator.GenerateRandomPassword(int)"/>
        /// to generate a random password.
        */
        /// <include file='XmlFile.xml' path='doc/members/member[@name="M:CsharpFundamentals.CsharpBasics.Genrator.GenerateId(System.String,System.String,System.Nullable{System.DateTime})"]/*'/>
        public static string GenerateId(
            string fname,
            string lname,
            DateTime? hireDate)
        {
            // First name cannot be null.
            if (fname == null)
                throw new ArgumentNullException(
                    $"{nameof(fname)} cannot be null"
                );

            // Last name cannot be null.
            if (lname == null)
                throw new ArgumentNullException(
                    $"{nameof(lname)} cannot be null"
                );

            // Use the current date if no date is provided.
            if (hireDate == null)
            {
                hireDate = DateTime.Now;
            }
            // The hire date cannot be in the past.
            else if (hireDate.Value < DateTime.Now.Date)
            {
                throw new Exception(
                    $"{nameof(hireDate)} cannot be in the past"
                );
            }

            // Get the last two digits of the year.
            var year = hireDate.Value.ToString("yy");

            // Get the month as two digits.
            var month = hireDate.Value.ToString("MM");

            // Get the day as two digits.
            var day = hireDate.Value.ToString("dd");

            // Generate the ID and increase LastId.
            return
                $"{fname.First()}{lname.First()} " +
                $"{year} {month} {day} " +
                $"{(LastId++).ToString().PadLeft(2, '0')}";
        }

        public static string GenerateRandomPassword(int length)
        {
            // Allowed characters for the password.
            const string characters =
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" +
                "123456789";

            // Create a random number generator.
            Random random = new Random();

            string password = "";

            // Add random characters until the required length is reached.
            for (int i = 0; i < length; i++)
            {
                int randomIndex = random.Next(characters.Length);

                password += characters[randomIndex];
            }

            return password;
        }
    }
}
