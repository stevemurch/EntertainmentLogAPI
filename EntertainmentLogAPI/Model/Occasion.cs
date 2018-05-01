using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EntertainmentLogAPI.Model.MongoDbContext;

namespace EntertainmentLogAPI.Model
{
    public enum OccasionType { Breakfast, Brunch, Lunch, Dinner, Cocktails, Party, Thanksgiving, Easter, Christmas, Halloween, FourthOfJuly, Boating, HolidayOther }
    public enum Season { Winter, Spring, Summer, Fall }


    public class Occasion
    {
        public string Id { get; set; }
        public string Title {  get; set; }
        public DateTime? Date { get; set; }
        public List<Person> Persons { get; set; }
        public string Notes { get; set; }
        public OccasionType Type { get; set; }


        public static Occasion AddOccasion(Occasion occ)
        {

            MongoDBContext dbContext = new MongoDBContext();
            occ.Id = Guid.NewGuid().ToString();
            dbContext.Occasions.InsertOne(occ);
            return occ;
        }

        internal static IEnumerable<Occasion> GetAllFromDb()
        {
            MongoDBContext dbContext = new MongoDBContext();
            return dbContext.Occasions.Find(m=>true).ToList();
        }


        internal static IEnumerable<Occasion> GetAll()
        {
            var personList = new List<Person>
            {
                new Person{FirstName="Steve",
                LastName = "Murch"}
            };
            List<Occasion> dummyValues = new List<Occasion>();
            for(int i=0; i<5; i++)
            {
                dummyValues.Add(new Occasion
                {
                    Title = "Brunch with X and Y "+i,
                    Date = DateTime.Now.AddDays(-365+i),
                    Notes = "Note "+i,
                    Persons = personList,
                    Type = OccasionType.Brunch
                });
            }
            return dummyValues;
        }

        internal static Occasion GetById(string id)
        {
            Occasion theOcc = new Occasion();
            return theOcc;
        }

        internal static void DeleteById(string id)
        {
            
        }

        internal static Occasion AddNew(
            DateTime date, 
            List<Person> persons,
            string Notes,
            OccasionType type)
        {
            Occasion theNewOccasion = new Occasion();

            return theNewOccasion;

        }
    }
}
