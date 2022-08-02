using Services.Interfaces;
using Services.ServicesDTO;

namespace Services.Queries
{
    public partial class ServiceQueries : IServiceQueries
    {
        public async Task<List<LogsDTO>> GetAllLogs()
        {
            var allLogs = await _repositoryQueries.GetAllLogs();

            List<LogsDTO> result = new List<LogsDTO>();

            if (allLogs == null)
            {
                return null;
            }

            foreach (var logs in allLogs)
            {
                result.Add(new LogsDTO()
                {
                    LogId = logs.log_id,
                    LogDescription = logs.log_description,
                    AddedBy = logs.added_by,
                    LogDate = logs.log_date
                });
            }
            return result;
        }
    }
}
