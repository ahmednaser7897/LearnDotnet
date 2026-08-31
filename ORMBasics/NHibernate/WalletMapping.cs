using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace ORMBasics.NHibernate
{
    public class WalletMapping : ClassMapping<NWallet>
    {
        public WalletMapping()
        {
            // Configure the primary key mapping.
            Id(
                x => x.Id,
                c =>
                {
                    // Use the database identity column to generate IDs.
                    c.Generator(Generators.Identity);

                    // Specify the .NET type of the ID.
                    c.Type(NHibernateUtil.Int32);

                    // Map the property to the Id column.
                    c.Column("Id");

                    // Treat 0 as the unsaved value.
                    c.UnsavedValue(0);
                }
            );

            // Configure the Holder property mapping.
            Property(
                x => x.Holder,
                c =>
                {
                    // Set the maximum length of the Holder column.
                    c.Length(50);

                    // Store the value as a non-Unicode string.
                    c.Type(NHibernateUtil.AnsiString);

                    // The Holder column cannot contain NULL.
                    c.NotNullable(true);
                }
            );

            // Configure the Balance property mapping.
            Property(
                x => x.Balance,
                c =>
                {
                    // Map Balance to a decimal database type.
                    c.Type(NHibernateUtil.Decimal);

                    // The Balance column cannot contain NULL.
                    c.NotNullable(true);
                }
            );

            // Map this class to the Wallets table.
            Table("Wallets");
        }
    }
}
