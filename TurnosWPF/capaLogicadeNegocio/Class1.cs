using capaAccesoaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
namespace capaLogicadeNegocio
{
    internal class clsLogin
    {
        private clsManejador M = new clsManejador();
        public string m_usuario
        {
            get;
            set;
        }
        public string m_clave
        {
            get;
            set;
        }
        public string Registrar_Usuario()
        {
            return "";
        }
    }
    public class clsTestConnection
    {
        private clsManejador M = new clsManejador();
        public bool Probar_Conexion()
        {
            bool result = false;
            try
            {
                result = this.M.Probar_Conexion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public void Limpiar_CadenaConexion()
        {
            this.M.Limpiar_CadenaConexion();
        }
    }
    public class cls_clasificacion
    {
        private clsManejador M = new clsManejador();
        public int id
        {
            get;
            set;
        }
        public string codigo
        {
            get;
            set;
        }
        public string tipo_atencion
        {
            get;
            set;
        }
        public DataTable sp_listar_clasificacion()
        {
            DataTable result;
            try
            {
                result = this.M.Listar_SP("sp_listar_clasificacion", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_buscar_clasificacion_xcodigo()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@codigo", this.codigo));
                result = this.M.Listar_SP("sp_buscar_clasificacion_xcodigo", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_registrar_clasificacion()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@codigo", this.codigo));
                list.Add(new clsParametros("@tipo_atencion", this.tipo_atencion));
                result = this.M.Listar_SP("sp_registrar_clasificacion", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_actualizar_clasificacion()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@id", this.id));
                list.Add(new clsParametros("@codigo", this.codigo));
                list.Add(new clsParametros("@tipo_atencion", this.tipo_atencion));
                result = this.M.Listar_SP("sp_actualizar_clasificacion", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_eliminar_clasificaciones()
        {
            DataTable result;
            try
            {
                result = this.M.Listar_SP("sp_eliminar_clasificaciones", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
    public class cls_cola
    {
        private clsManejador M = new clsManejador();
        public long id
        {
            get;
            set;
        }
        public string codigo_numeracion
        {
            get;
            set;
        }
        public int modulo
        {
            get;
            set;
        }
        public int estado
        {
            get;
            set;
        }
        public string creado_por
        {
            get;
            set;
        }
        public string atendido_por
        {
            get;
            set;
        }
        public DataTable sp_registrar_cola()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@codigo_numeracion", this.codigo_numeracion));
                list.Add(new clsParametros("@modulo", this.modulo));
                list.Add(new clsParametros("@estado", this.estado));
                list.Add(new clsParametros("@creado_por", this.creado_por));
                list.Add(new clsParametros("@atendido_por", this.atendido_por));
                result = this.M.Listar_SP("sp_registrar_cola", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_actualizar_cola()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@id", this.id));
                list.Add(new clsParametros("@estado", this.estado));
                result = this.M.Listar_SP("sp_actualizar_cola", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_borrar_colas()
        {
            DataTable result;
            try
            {
                result = this.M.Listar_SP("sp_borrar_colas", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_listar_cola()
        {
            DataTable result;
            try
            {
                result = this.M.Listar_SP("sp_listar_cola", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
    public class cls_ticket
    {
        private string token = Environment.MachineName;
        private clsManejador M = new clsManejador();
        public long id
        {
            get;
            set;
        }
        public string codigo
        {
            get;
            set;
        }
        public string codigo_numeracion
        {
            get;
            set;
        }
        public int modulo
        {
            get;
            set;
        }
        public int estado
        {
            get;
            set;
        }
        public DataTable sp_registrar_ticket()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@codigo", this.codigo));
                list.Add(new clsParametros("@token", this.token));
                result = this.M.Listar_SP("sp_registrar_ticket", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_actualizar_ticket()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@id", this.id));
                list.Add(new clsParametros("@codigo_numeracion", this.codigo_numeracion));
                list.Add(new clsParametros("@modulo", this.modulo));
                list.Add(new clsParametros("@estado", this.estado));
                result = this.M.Listar_SP("sp_actualizar_ticket", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_borrar_tickets()
        {
            DataTable result;
            try
            {
                result = this.M.Listar_SP("sp_borrar_tickets", null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_listar_tickets_xcodigo()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@codigo", this.codigo));
                result = this.M.Listar_SP("sp_listar_tickets_xcodigo", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_listar_tickets_xcodigo_xestado()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@codigo", this.codigo));
                list.Add(new clsParametros("@estado", this.estado));
                result = this.M.Listar_SP("sp_listar_tickets_xcodigo_xestado", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public DataTable sp_asignar_ticket()
        {
            List<clsParametros> list = new List<clsParametros>();
            DataTable result;
            try
            {
                list.Add(new clsParametros("@id", this.id));
                list.Add(new clsParametros("@modulo", this.modulo));
                result = this.M.Listar_SP("sp_asignar_ticket", list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
