using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using PROYECTO.models;

namespace PROYECTO.controler
{
    public class emplecontroler
    {
        SQLiteAsyncConnection _connection;
        public emplecontroler(string DBPath)
        {
            _connection = new SQLiteAsyncConnection(DBPath);
            _connection.CreateTableAsync<empleado>().Wait();
        }
        public Task<int> saveempleAsync(empleado emple)
        {
            if (emple.codigo != 0)
            {
                return _connection.UpdateAsync(emple);
            }
            else
            {
                return _connection.InsertAsync(emple);
            }
        }

        public Task<int> DeleteEmple(empleado empleado)
        {
            return _connection.DeleteAsync(empleado);
        }
       
        public Task<List<empleado>> GetEmpleadosAsync()
        {
            return _connection.Table<empleado>().ToListAsync();
        }

        public Task<empleado> GetEmpleadoByIdAsync(int pid)
        {
            return _connection.Table<empleado>().Where(i => i.codigo == pid).FirstOrDefaultAsync();
        }

    }
}