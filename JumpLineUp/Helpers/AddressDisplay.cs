using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.Mvc;
using JumpLineUp.Models;

namespace JumpLineUp.Helpers
{
    public static class AddressDisplay
    {
        
        public static string Display(int clientId = 0, int fosterParentId= 0, int blcsOfficeId = 0)
        {
            var address = "";
            var _context = new ApplicationDbContext();

            if (clientId > 0)
            {
                var client = _context.Clients.SingleOrDefault(c => c.Id == clientId);

                address = client.Street1 + ", ";
                if (client.Street2.Length > 0)
                {
                    address +=  client.Street2 + ", ";
                }
                address += client.City + ", " + client.State + ". " + client.Zip;


            }

            if (fosterParentId > 0)
            {
                var fosterParent = _context.FosterParents.SingleOrDefault(c => c.Id == fosterParentId);

                address = fosterParent.Street1 + ", ";
                if (fosterParent.Street2.Length > 0)
                {
                    address += fosterParent.Street2 + ", ";
                }
                address += fosterParent.City + ", " + fosterParent.State + ". " + fosterParent.Zip;


            }

            if (blcsOfficeId > 0)
            {
                var office = _context.BlcsOffices.SingleOrDefault(c => c.Id == blcsOfficeId);

                address = office.Street1 + ", ";
                if (office.Street2.Length > 0)
                {
                    address += office.Street2 + ", ";
                }
                address += office.City + ", " + office.State + ". " + office.Zip;


            }

            return address;

           
        }

    }
}