using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

using Craze.Data.Abstract;
using Craze.Domain;

namespace Craze.Data.Sqlite
{
    public class SqliteAnimalRepository : IAnimalRepository
    {
        readonly SQLiteAsyncConnection database;

        public SqliteAnimalRepository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.DeleteAllAsync<Animal>();
            database.CreateTableAsync<Animal>().Wait();

            /*
            InsertAnimal(new Animal()
            {
                Id = 0,
                Name = "Mamoth",
                Description = "A wooly ellephant",
                Icon = "https://image.flaticon.com/icons/svg/170/170506.svg",
                VideoId = "https://www.youtube.com/watch?v=LKTUDjZXegY"
            });
            */
        }

        public Animal GetAnimalById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Animal> GetAnimals()
        {
            IList<Animal> animals = database.Table<Animal>().ToListAsync().Result;
            return animals;
        }

        public Animal GetAnimalByName(string aName)
        {
            return database.Table<Animal>().Where(i => i.Name == aName).FirstOrDefaultAsync().Result;
        }

        public void InsertAnimal(Animal anAnimal)
        {
            if (GetAnimalByName(anAnimal.Name) != null) {
                throw new Exception();
            }

            if (anAnimal.Id != 0) {
                database.UpdateAsync(anAnimal);
            }
            else {
                database.InsertAsync(anAnimal);
            }
        }
    }
}
