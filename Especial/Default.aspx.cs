using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using System.Linq;
using System.Xml.Linq;
public partial class _Default : System.Web.UI.Page
{
    public int Zoom { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        Zoom = 14;
    }
    protected void LbCitiesSelectedIndexChanged(object sender, EventArgs e)
        {
            var xml = XDocument.Load(Request.MapPath("~/Places.xml"));
            var query = from q in xml.Descendants("Place")
                        select new
                        {
                            Id = q.Attribute("Id").Value,
                            City = q.Attribute("City").Value,
                            Lat = q.Attribute("Lat").Value,
                            Lon = q.Attribute("Lon").Value
                        };
            var place = query.Where(q => q.Id == LbCities.SelectedValue).ToList().FirstOrDefault();
            if (place != null)
            {
                this.lat.Value = place.Lat;
                this.lon.Value = place.Lon;
            }
        }
 
        protected void BtnGoClick(object sender, EventArgs e)
        {
            const String welcome = "Bienvenid@ a {0}";
            TextCity.Text = String.Format(welcome, LbCities.SelectedItem);
        }
    
}