using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MongoDbPOC
{
    public class Repository
    {
        public Repository(IMongoDatabase db)
        {
            PersonCollection = db.GetCollection<PersonCopy>("people");
            DogCollection = db.GetCollection<DogCopy>("dogs");
        }

        public IMongoCollection<PersonCopy> PersonCollection { get; set; }
        public IMongoCollection<DogCopy> DogCollection { get; set; }

        public IMongoQueryable<PersonCopy> Persons
        {
            get => PersonCollection.AsQueryable();
        }

        public IMongoQueryable<DogCopy> Dogs
        {
            get => DogCollection.AsQueryable();
        }

        public IQueryable<Person> GetList()
        {
            return Persons.GroupJoin(Dogs, copy => copy.id, copy => copy.personid, (person, dogs) => new Person()
            {
                id = person.id,
                dogs = dogs.Select(copy => new Dog
                {
                    dogid = copy.dogid,
                    name = copy.name
                }),
                name = person.name
            });
        }

        public void SeedData()
        {
            DogCollection.InsertMany(new []
            {
                new DogCopy()
                {
                    dogid = 0,
                    name = "LáaszlóKutyája",
                    personid = 0
                },
                new DogCopy()
                {
                    dogid = 1,
                    name = "Mordáj",
                    personid = 1
                },
                new DogCopy()
                {
                    dogid = 2,
                    name = "Pamacs",
                    personid = 1
                },
                new DogCopy()
                {
                    dogid = 3,
                    name = "Blackie",
                    personid = 2
                },
                new DogCopy()
                {
                    dogid = 4,
                    name = "Maszlag",
                    personid = 2
                },
                new DogCopy()
                {
                    dogid = 5,
                    name = "Labda",
                    personid = 3
                },
                new DogCopy()
                {
                    dogid = 6,
                    name = "Szöszmösz",
                    personid = 3
                },
                new DogCopy()
                {
                    dogid = 7,
                    name = "Mandarin",
                    personid = 3
                },
                new DogCopy()
                {
                    dogid = 8,
                    name = "Adbal",
                    personid = 4
                }
            });
            PersonCollection.InsertMany(new []
            {
                new PersonCopy
                {
                    id = 0,
                    dogids = new[] {0},
                    name = "Láaszló"
                },
                new PersonCopy
                {
                    id = 1,
                    dogids = new[] {1, 2},
                    name = "Gáborka"
                },
                new PersonCopy
                {
                    id = 2,
                    dogids = new[] {3, 4},
                    name = "Áronka"
                },
                new PersonCopy
                {
                    id = 3,
                    dogids = new[] {5, 6, 7},
                    name = "Matyika"
                },
                new PersonCopy
                {
                    id = 4,
                    dogids = new[] {8},
                    name = "Ariel"
                }
            });
        }
    }
}