using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATeam.Objects
{
    using System.ComponentModel;

    using ATeam.Helpers;

    public class Attendee
    {
        public Attendee()
        {
            ObjectHelper.SetDefaultValues(this);
            this.Name = RandomDataHelper.GetRandomString(5);
            this.SurName = RandomDataHelper.GetRandomString(5);
            this.Email = RandomDataHelper.GetRandomMail();
            this.PhoneNumber = RandomDataHelper.GetRandomNumber(9);
        }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [DefaultValue(true)]
        public bool IsEnglish { get; set; }

        [DefaultValue(true)]
        public bool IsPaperExam { get; set; }

        [DefaultValue("02.10.2015")]
        public string CertificateIssueDate { get; set; }

        [DefaultValue("12345")]
        public string CertificateNumber { get; set; }

        [DefaultValue("SJSI")]
        public string CertificateIssuer { get; set; }

        [DefaultValue(true)]
        public bool FillPhone { get; set; }

        [DefaultValue(0)]
        public int SelectedProductId { get; set; }
    }
}
