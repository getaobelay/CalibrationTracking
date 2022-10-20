using Microsoft.EntityFrameworkCore;

namespace CalibrationTracking.Abstractions.Extensions
{
    public static class DbConnectionExtension
    {
        public static void TestConnection<TContext>(this TContext context)
            where TContext : DbContext
        {
            try
            {
                context.Database.OpenConnection();
                context.Database.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("לא נמצא חיבור פעיל לממסד הנתונים");
            }
        }
    }
}