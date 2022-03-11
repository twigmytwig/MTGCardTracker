using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Card_Tracker_v3.Models
{
    public class ScryFallSearchResults
    {
        public string id { get; set; }
        public string oracle_id { get; set; }
        //public string multiverse_ids { get; set; }
        public int mtgo_id { get; set; }
        public int tcgplayer_id { get; set; }
        public int cardmarket_id { get; set; }
        public string name { get; set; }
        public string lang { get; set; }
        public string released_at { get; set; }
        public string uri { get; set; }
        public string scryfall_uri { get; set; }
        public string layout { get; set; }
        public bool highres_image { get; set; }
        public string image_status { get; set; }

        public ImageUris image_uris { get; set; }
        //HERE NEEDS TO BE A LIST OF IMAGE URIS
        public string mana_cost { get; set; }
        public float CMC { get; set; }
        public string type_line { get; set; }
        public string oracle_text { get; set; }
        public string power { get; set; }
        public string toughness { get; set; }
        public List<char> colors { get; set; }
        public List<char> color_indicator { get; set; }
        public List<char> color_indentity { get; set; }
        //KEy WORDS SHOULD GO HERE
        //ALL PARTS WOULD BE NEXT

        
    }
    public class ImageUris
    {
        public string small { get; set; }
        public string normal { get; set; }
        public string large { get; set; }
        public string png { get; set; }
        public string art_crop { get; set; }
        public string border_crop { get; set; }

    }
}
