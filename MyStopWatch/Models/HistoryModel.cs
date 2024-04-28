using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace MyStopWatch.Models
{
    internal class HistoryModel
    {
        private MyStopWatchContext DbContext { get; set; }
        internal BindingList<Work> Works { get; private set; }

        internal HistoryModel()
        {
            DbContext = new MyStopWatchContext();
#if DEBUG
            DbContext.Database.EnsureDeleted();
#endif
            DbContext.Database.Migrate();
            var item = DbContext.Works.FirstOrDefault();
            if (item == null)
            {
                DbContext.Works.Add(new Work { Title = "Sample" });
                DbContext.SaveChanges();
            }
            DbContext.Works.Load();

            Works = DbContext.Works.Local.ToBindingList();
        }
    }
}