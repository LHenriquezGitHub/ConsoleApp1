using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1.POCO
{
    public class Innovid_metadata
    {
        public string Innovid_metadataID { get; set; }

        public int idadvagency { get; set; }

        public string advagency { get; set; }

        public int idadvertiser { get; set; }

        public string advertiser { get; set; }

        public int idcampaign { get; set; }

        public string campaign { get; set; }

        public string brand { get; set; }

        public int idbrand { get; set; }

        public DateTime campaignstart { get; set; }

        public DateTime campaignend { get; set; }

        public int idpublisher { get; set; }

        public string publisher { get; set; }

        public int idplacement { get; set; }

        public string placement { get; set; }

        public int idvideo { get; set; }

        public string video { get; set; }

        public string format { get; set; }

        public string hash { get; set; }

        public string FileGUID { get; set; }

        public DateTime CreatedDate { get; set; }

    }




}
