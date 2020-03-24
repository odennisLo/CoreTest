using Core.Connection;
using Core.Models;
using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Core.DAL
{
    public class DataDal
    {
        //private readonly IDbConnection dbcontent;
        private readonly ConnectionString _context;
        public DataDal(ConnectionString connectionString)
        {
            _context = connectionString;
            //_context = new SqlConnection(connectionString.Value); ;
        }
        private ApiData<CalendarModel> dataList;
        //public DataDal()
        //{
        //    //var dbContext = new ConnectionFactory();
        //    //_context = dbContext.CreateConnection();
        //    dbcontent =new SqlConnection(connectionString.Value);
        //}
        internal async Task<ApiData<CalendarModel>> Insert(CalendarModel calendarModel)
        {
            const string sqlStr = "INSERT INTO Calendar VALUES(@Title,@StartDate,@EndDate,@Content,@InsertDate,@UpdateDate,@IP) \r\n";            
            try
            {
                using (var conn = new SqlConnection(_context.Value))
                {
                    await conn.QueryAsync<CalendarModel>(sqlStr, calendarModel).ConfigureAwait(false);
                }
                dataList = new ApiData<CalendarModel>
                {                  
                    Success = true
                };
            }
            catch (Exception ex)
            {
                dataList = new ApiData<CalendarModel>
                {
                    Msg = ex.Message
                };
            }
            return dataList;            
        }
        //internal async Task<ApiData<CalendarModel>> Update(CalendarModel calendarModel)
        //{
        //    const string sqlStr = "Update Calendar set ContentText=@ContentText,UpdateDate=@UpdateDate,IP=@IP) Where SerId=@SerID\r\n";
        //    try
        //    {
        //        await _context.QueryAsync<CalendarModel>(sqlStr, calendarModel).ConfigureAwait(false);
        //        dataList = new ApiData<CalendarModel>
        //        {                    
        //            Success = true
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        dataList = new ApiData<CalendarModel>
        //        {
        //            Msg = ex.Message
        //        };
        //    }
        //    return dataList;
        //}
        internal async Task<ApiData<CalendarModel>> GerCalendarList()
        {
            const string sqlStr = "Select * From Calendar\r\n";
            try
            {
                using (var conn = new SqlConnection(_context.Value))
                {
                    dataList = new ApiData<CalendarModel>
                    {
                        Data = await conn.QueryAsync<CalendarModel>(sqlStr).ConfigureAwait(false),
                        Success = true
                    };
                }
            }
            catch (Exception ex)
            {
                dataList = new ApiData<CalendarModel>
                {
                    Msg = ex.Message
                };
            }
            return dataList;
        }
        //internal async Task<ApiData<CalendarModel>> Delete(long SerId)
        //{
        //    const string sqlStr = "Delete * From CalendarModel Where SerId=@SerId\r\n";
        //    try
        //    {
        //        await _context.QueryAsync<CalendarModel>(sqlStr, SerId).ConfigureAwait(false);
        //        dataList = new ApiData<CalendarModel>
        //        {                   
        //            Success = true
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        dataList = new ApiData<CalendarModel>
        //        {
        //            Msg = ex.Message
        //        };
        //    }
        //    return dataList;
        //}

    }
}
