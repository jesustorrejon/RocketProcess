using Dapper;
using Dapper.Oracle;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using RocketProcess.Repositories.App;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketProcess.Repositories.Data
{
    public class DbHelper
    {
        private readonly IDbConnection _dbConnection;

        private string _ConnectionString = "";
        private OracleConnection _Connection;
        private CommandType _Commandtype;
        private OracleCommand _command;
        private OracleDynamicParameters _oracleParameter;
        public OracleConnection Connection { get => _Connection; set => _Connection = value; }
        public CommandType CommandType { get => _Commandtype; set => _Commandtype = value; }
        public OracleDynamicParameters OracleParameter { get => _oracleParameter; set => _oracleParameter = value; }
        public OracleCommand Command { get => _command; set => _command = value; }

        public DbHelper(CommandType CommandType)
        {
            _ConnectionString = ClsCommon.ConnectionString;
            _Commandtype = CommandType;
            _Connection = new OracleConnection();
            Connection.ConnectionString = _ConnectionString;
            Command = Connection.CreateCommand();
            Command.Connection = Connection;
        }

        private void BeginTransaction()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            Command.Transaction = Connection.BeginTransaction();
        }

        // Metodo encargado de confirmar la transaccion a la base de datos
        private void CommitTransaction()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Command.Transaction.Commit();
                Connection.Close();
            }
        }

        // Validaciones que no hayan inconsistencias en la base de datos, en caso que haya desace los cambios a como estaba
        private void RollbackTransaction()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Command.Transaction.Rollback();
                Connection.Close();
            }
        }

        public int CRUD(string query)
        {
            Command.CommandText = query;
            Command.CommandType = _Commandtype;
            int i = -1;

            try
            {
                if (Connection.State == ConnectionState.Closed)
                {
                    Connection.Open();
                }
                BeginTransaction();
                i = Command.ExecuteNonQuery(); // contar filas afectadas.
                CommitTransaction();
            }
            catch (Exception ex)
            {
                RollbackTransaction();
                //logs
            }
            finally
            {
                Command.Parameters.Clear();
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    Connection.Dispose(); // liberar recursos utilizados
                    Command.Dispose();
                }
            }

            return i;

        }

        public string GetDataTable(string query, string strNombreTabla = "Modelo")
        {
            strNombreTabla = strNombreTabla is null? "Modelo" : strNombreTabla;

            OracleDataAdapter adapter = new OracleDataAdapter();
            Command.CommandText = query;
            Command.CommandType = _Commandtype;
            adapter.SelectCommand = Command;
            DataSet ds = new DataSet();

            string resultado = "";

            try
            {
                adapter.Fill(ds, strNombreTabla);
                resultado = JsonConvert.SerializeObject(ds, Formatting.Indented);
            }
            catch (Exception ex)
            {
                resultado = "ERROR : " + ex.Message;
                //logs
            }
            finally
            {
                Command.Parameters.Clear();
                if (Connection.State == ConnectionState.Open)
                {
                    Connection.Close();
                    Connection.Dispose();
                    Command.Dispose();
                }
            }

            
            //return ds.Tables[0];
            return resultado;
        }

        //Metodo para auxiliar los parametros solicitados por las consultas o procedimientos almacenados
        public void AddParameters(string name, object value, OracleDbType oracleDbType, ParameterDirection parameterDirection)
        {
            OracleParameter parm = new OracleParameter();
            parm.ParameterName = name;
            parm.Value = value;
            parm.OracleDbType = oracleDbType;
            parm.Direction = parameterDirection;

            Command.Parameters.Add(parm);
        }

        public void AddParameters(string name, OracleDbType oracleDbType, ParameterDirection parameterDirection)
        {
            OracleParameter parm = new OracleParameter();
            parm.ParameterName = name;
            parm.Value = null;
            parm.OracleDbType = oracleDbType;
            parm.Direction = parameterDirection;

            Command.Parameters.Add(parm);
        }
    }
}
