using CarrierApplication1.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Models
{
    public class CarrierRepository
    {
        public List<CarrierView> GetCarriers()
        {
            List<CarrierView> carriers = new List<CarrierView>();

            using (DevEntities db = new DevEntities()) {

                carriers = (from c in db.Carriers
                           orderby c.CarrierName
                           select new CarrierView
                           {
                               ID = c.ID,
                               CarrierName = c.CarrierName,
                               Address = c.Address,
                               Address2 = c.Address2,
                               City = c.City,
                               State = c.State,
                               Zip = c.Zip,
                               Zip2 = c.Zip2,
                               Contact = c.Contact,
                               Phone = c.Phone,
                               Fax = c.Fax,
                               Email = c.Email
                           }).ToList();
            }

            return carriers;
        }

        public CarrierView FindCarrier(int id)
        {
            using (DevEntities db = new DevEntities())
            {

                return (from c in db.Carriers
                        where c.ID == id
                        select new CarrierView
                        {
                            ID = c.ID,
                            CarrierName = c.CarrierName,
                            Address = c.Address,
                            Address2 = c.Address2,
                            City = c.City,
                            State = c.State,
                            Zip = c.Zip,
                            Zip2 = c.Zip2,
                            Contact = c.Contact,
                            Phone = c.Phone,
                            Fax = c.Fax,
                            Email = c.Email
                        }).SingleOrDefault();
            }
        }

        public void AddCarrier(Carrier carrier)
        {
            using (DevEntities db = new DevEntities())
            {
                db.Carriers.Add(carrier);
                db.SaveChanges();
            }
        }
    }
}