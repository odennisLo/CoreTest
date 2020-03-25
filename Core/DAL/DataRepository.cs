using Core.Models;
using Dapper;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Core.DAL
{
    public class DataRepository
    {
        private readonly ConnectionString _context;
        public DataRepository(ConnectionString connectionString)
        {
            _context = connectionString;
        }
        private ApiData<CalendarModel> dataList;

        internal async Task<ApiData<CalendarModel>> Insert(CalendarModel calendarModel)
        {
            const string sqlStr = "INSERT INTO Calendar VALUES(@Title,@StartDate,@EndDate,@InsertDate,@UpdateDate,@IP) \r\n";
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
        internal async Task<ApiData<CalendarModel>> Update(CalendarModel calendarmodel)
        {
            const string sqlStr = "UPDATE Calendar set StartDate=@StartDate,UpdateDate=GETDATE(),IP=@IP where SerID=@SerID \r\n";
            try
            {
                using var conn = new SqlConnection(_context.Value);
                await conn.QueryAsync<CalendarModel>(sqlStr, new { StartDate = calendarmodel.StartDate, SerID = calendarmodel.SerID, IP = calendarmodel.IP }).ConfigureAwait(false);
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
        internal async Task<ApiData<CalendarModel>> GerCalendarList()
        {
            const string sqlStr = "Select * From Calendar\r\n";
            try
            {
                using var conn = new SqlConnection(_context.Value);
                dataList = new ApiData<CalendarModel>
                {
                    Data = await conn.QueryAsync<CalendarModel>(sqlStr).ConfigureAwait(false),
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
        internal async Task<ApiData<CalendarModel>> Delete(long SerId)
        {
            const string sqlStr = "Delete From Calendar Where SerId=@SerId\r\n";
            try
            {
                using var conn = new SqlConnection(_context.Value);
                await conn.QueryAsync(sqlStr, new
                {
                    SerId = SerId
                }).ConfigureAwait(false);
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

    }
}
