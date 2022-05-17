using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Models
{
    public interface IGenericDataService<T> where T: class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(int page, int elements);
        T? GetById(int id);
    }

    public class GenericDataService<T> : IGenericDataService<T> where T : class
    {
        private NorthwindContext database = new NorthwindContext();
        private DbSet<T> table;

        public GenericDataService()
        {
            table = database.Set<T>();
        }

        public void Add(T entity)
        {
            table.Add(entity);
            database.SaveChanges();
        }

        public void Delete(T entity)
        {
            database.Entry(entity).State = EntityState.Deleted;
            database.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return table;
        }

        public IEnumerable<T> GetAll(int page, int elements)
        {
            return table.Skip( (page-1) * elements).Take(elements);
        }

        public T? GetById(int id)
        {
            return table.Find(id);
        }

        public void Update(T entity)
        {
            database.Entry(entity).State = EntityState.Modified;
            database.SaveChanges();
        }
    }

}
