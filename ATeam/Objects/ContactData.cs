using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Objects
{
    using System.ComponentModel;

    using ATeam.Helpers;
    using Enumerators;

    public class ContactData
    {
        public ContactData()
        {
            ObjectHelper.SetDefaultValues(this);
            this.PersonDataName = RandomDataHelper.GetRandomString(5);
            this.PersonDataSurname = RandomDataHelper.GetRandomString(5);
            this.PersonDataPhone = RandomDataHelper.GetRandomNumber(9);
            this.PersonDataEmail = RandomDataHelper.GetRandomMail();
            this.ContactName = RandomDataHelper.GetRandomString(5);
            this.ContactSurname = RandomDataHelper.GetRandomString(5);
            this.ContactAddress = RandomDataHelper.GetRandomString(5);
            this.ContactCity = string.Format("Waw{0}", RandomDataHelper.GetRandomNumber(2));
            this.ContactPostCode = string.Format("0{0}-{1}", RandomDataHelper.GetRandomNumber(1), RandomDataHelper.GetRandomNumber(3));
            this.InvoiceCompanyName = RandomDataHelper.GetRandomString(5);
            this.InvoiceEmail = RandomDataHelper.GetRandomMail();
            this.InvoiceAddress = RandomDataHelper.GetRandomString(5);
            this.InvoiceCity = string.Format("Waw{0}", RandomDataHelper.GetRandomNumber(2));
            this.InvoicePostalCode = string.Format("0{0}-{1}", RandomDataHelper.GetRandomNumber(1), RandomDataHelper.GetRandomNumber(3));
            this.LetterCompanyName = RandomDataHelper.GetRandomString(5);
            this.LetterAddress = RandomDataHelper.GetRandomString(5);
            this.LetterCity = string.Format("Waw{0}", RandomDataHelper.GetRandomNumber(2));
            this.LetterPostalCode = string.Format("0{0}-{1}", RandomDataHelper.GetRandomNumber(1), RandomDataHelper.GetRandomNumber(3));
            this.Comment = string.Format("A-Team {0}", DateTime.Now);
        }

        public string PersonDataName { get; set; }

        public string PersonDataSurname { get; set; }

        public string PersonDataEmail { get; set; }

        public string PersonDataPhone { get; set; }

        [DefaultValue(true)]
        public bool PersonSendDataPhone { get; set; }

        public string ContactName { get; set; }

        public string ContactSurname { get; set; }
        
        public string ContactPostCode { get; set; }

        public string ContactCity { get; set; }

        public string ContactAddress { get; set; }

        [DefaultValue(false)]
        public bool FillComment { get; set; }

        public string Comment { get; set; }

        [DefaultValue(InvoiceType.None)]
        public InvoiceType InvoiceType { get; set; }

        public string InvoiceCompanyName { get; set; }

        public string InvoicePostalCode { get; set; }

        public string InvoiceCity { get; set; }

        public string InvoiceAddress { get; set; }

        public string InvoiceNip { get; set; }

        public string InvoiceEmail { get; set; }

        [DefaultValue(true)]
        public bool InvoiceAddressIsTheSame { get; set; }

        public string LetterCompanyName { get; set; }

        public string LetterPostalCode { get; set; }

        public string LetterCity { get; set; }

        public string LetterAddress { get; set; }

        [DefaultValue(true)]
        public bool AcceptedPrivacyPolicy { get; set; }

        [DefaultValue(true)]
        public bool AcceptedMarketingPolicy { get; set; }
    }
}
