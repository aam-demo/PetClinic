using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetClinic.Models;
using System.Web.Mvc;

namespace PetClinic
{
    /// <summary>
    /// domain (business) layer
    /// </summary>
    public class DL
    {
        public static List<VET> AllVets()
        {
            var ctx = new CodeFirstContext();

            return ctx.VET.ToList();
        }
        public static OWNER GetOwner(int id)
        {
            var ctx = new CodeFirstContext();
            return ctx.OWNER.Find(id);

        }
        public static PET GetPet(int id)
        {
            var ctx = new CodeFirstContext();
            return ctx.PET.Find(id);

        }
        public static List<OWNER> AllOwners()
        {
            var ctx = new CodeFirstContext();
            return ctx.OWNER.OrderBy(x =>
           x.lastname).
            ToList();

        }
        public static List<OWNER> FindOwnerByLastname(string lastname)
        {
            if (!string.IsNullOrEmpty(lastname))
                lastname = lastname.Trim(); //framework trims ?

            var ctx = new CodeFirstContext();
            return ctx.OWNER.Where(x =>
             x.lastname == lastname) // case sensitive? do ToLower() ...?
             .ToList();

        }

        public static bool IsOwnerValid(OWNER model)
        {
            // magic
            // ....magic 

            return true;
        }

        public static void InsertOwner(OWNER o)
        {
            var ctx = new CodeFirstContext();

            ctx.OWNER.Add(o);

            if (ctx.SaveChanges() != 1) throw new Exception("insert problem");
        }
        public static List<System.Web.Mvc.SelectListItem> AllPetTypeDescriptions()
        {
            var ctx = new CodeFirstContext();

            var result = ctx.PET_TYPE.OrderBy(y => y.id)
            .ToList();

            var selectList = new List<SelectListItem>();

            foreach (var element in result)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.id.ToString(),
                    Text = element.description
                });
            }

            return selectList;
            //TODO stash/store somewhere 

        }
        public static void InsertPet(PET p)
        {
            var ctx = new CodeFirstContext();

            ctx.PET.Add(p);

            if (ctx.SaveChanges() != 1) throw new Exception("insert problem");
        }
        public static void InsertVisit(VISIT v)
        {
            var ctx = new CodeFirstContext();

            ctx.VISIT.Add(v);

            if (ctx.SaveChanges() != 1) throw new Exception("insert problem");
        }
    }

}
