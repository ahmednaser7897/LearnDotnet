using System;
using System.Collections.Generic;
using System.Text;

namespace ORMBasics.NHibernate
{
    public class NWallet
    {
        public virtual int Id { get; set; }
        public virtual string Holder { get; set; } =null!;
        public virtual decimal? Balance { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Holder: {Holder ?? "Unknown"}, Balance: {Balance ?? 0:C}";
        }
    }
}
