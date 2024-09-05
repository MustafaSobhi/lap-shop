using LapStore.Models;
namespace Bl
{
    public interface IUsers
    {
        public List<VwUsers> GetAll();
        public VwUsers GetById(string id);


    }

    public class ClsUsers : IUsers
    {
        LapShopContext context;
        public ClsUsers(LapShopContext ctx)
        {
            context = ctx;
        }
        public List<VwUsers> GetAll()
        {
            try
            {
                var lstusers = context.VwUsers.ToList();
                return lstusers;
            }
            catch
            {
                return new List<VwUsers>();
            }
        }

        //public bool Delete(string id)
        //{
        //    try
        //    {
        //        var item = GetById(id);
        //        item.CurrentState = 0;
        //        context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        public VwUsers GetById(string id)
        {
            try
            {

                var users = context.VwUsers.FirstOrDefault(a => a.UserId == id );
                return users;
            }
            catch
            {
                return new VwUsers();
            }
        }
    }
}
