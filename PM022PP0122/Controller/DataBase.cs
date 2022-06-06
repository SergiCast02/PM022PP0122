using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PM022PP0122.Models;
using SQLite;

namespace PM022PP0122.Controller
{
    public class DataBase
    {
        readonly SQLiteAsyncConnection dbase;
        /* Constructor de clase */
        public DataBase(string dbpath)
        {
            dbase = new SQLiteAsyncConnection(dbpath);

            // Crearemos las tablas de la base de datos
            dbase.CreateTableAsync<Empleado>(); // Creando la tabla de Empleado
            dbase.CreateTableAsync<Contactos>();
        }

        #region OperacionesEmple
        // CRUD - Create - Read - Update - Delete
        // Create
        public Task<int> EmpleSave(Empleado emple)
        {
            if(emple.id != 0)
            {
                return dbase.UpdateAsync(emple); // Update
            }
            else
            {
                return dbase.InsertAsync(emple);
            }
        }

        // Read
        public Task<List<Empleado>> obtenerListaEmple()
        {
            return dbase.Table<Empleado>().ToListAsync();
        }

        // Read V2
        public Task<Empleado> obtenerEmple(int pid)
        {
            return dbase.Table<Empleado>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        // Delete
        public Task<int> EmpleDelete(Empleado emple)
        {
            return dbase.DeleteAsync(emple);
        }

        #endregion Operaciones

        #region OperacionesContactos
        // CRUD - Create - Read - Update - Delete
        // Create
        public Task<int> ContactoSave(Contactos contacto)
        {
            if (contacto.id != 0)
            {
                return dbase.UpdateAsync(contacto); // Update
            }
            else
            {
                return dbase.InsertAsync(contacto);
            }
        }

        // Read
        public Task<List<Contactos>> obtenerListaContacto()
        {
            return dbase.Table<Contactos>().ToListAsync();
        }

        // Read V2
        public Task<Contactos> obtenerContacto(int cid)
        {
            return dbase.Table<Contactos>()
                .Where(i => i.id == cid)
                .FirstOrDefaultAsync();
        }

        // Delete
        public Task<int> EmpleContacto(Contactos contacto)
        {
            return dbase.DeleteAsync(contacto);
        }

        #endregion OperacionesContactos
    }
}