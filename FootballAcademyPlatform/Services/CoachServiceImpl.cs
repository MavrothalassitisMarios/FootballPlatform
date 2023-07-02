using AutoMapper;
using FootballAcademyPlatform.DAO;
using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Models;

namespace FootballAcademyPlatform.Services
{
    /// <summary>
    /// A  Coach Service layer that communicates with the controllers by getting
    /// the Coach DTO's and then pass simple model instances to the DAO layer for the CRUD actions
    /// </summary>
    public class CoachServiceImpl : ICoachService
    {
        private readonly ICoachDAO dao;
        private readonly IMapper mapper;

        public CoachServiceImpl(ICoachDAO dao, IMapper mapper)
        {
            this.dao = dao;
            this.mapper = mapper;
        }

        /// <summary>
        /// mapping the DTO to Coach instance and pass it to the DAO for the insert
        /// </summary>
        /// <param name="dto">The DTO for the insert action</param>
        public void InsertCoach(CoachCreateDTO? dto)
        {
            if (dto == null) return;

            Coach? coach = mapper.Map<Coach>(dto);
            try
            {
                dao.InsertC(coach);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// mapping the DTO to Coach instance and pass it to the DAO for the update
        /// </summary>
        /// <param name="dto">The DTO for the update action</param>
        public void UpdateCoach(CoachUpdateDTO? dto)
        {
            if (dto == null) return;

            Coach? coach = mapper.Map<Coach>(dto);
            try
            {
                dao.UpdateC(coach);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Get the Coach instance to be deleted by the id and then
        /// mapping the DTO to Coach instance and pass it to the DAO for the delete
        /// </summary>
        /// <param name="id">the Coach id to found and deleted by the DAO</param>
        /// <returns>The deleted Coach instance</returns>
        public CoachReadOnlyDTO? DeleteCoach(int id)
        {
            Coach? coach = null;
            CoachReadOnlyDTO? coachDto = null;
            try
            {
                coach = dao.GetCById(id);
                coachDto = mapper.Map<CoachReadOnlyDTO>(coach);
                if(coach == null) return null;
                dao.DeleteC(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return coachDto;
        }

        /// <summary>
        /// Get the instance from DAO and then do the mapping
        /// </summary>
        /// <param name="id">the id of Coach to be found</param>
        /// <returns>A Coach DTO instance</returns>
        public CoachReadOnlyDTO? GetCoachById(int id)
        {
            Coach? coach = null;
            try
            {
                coach = dao.GetCById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            CoachReadOnlyDTO coachDto = mapper.Map<CoachReadOnlyDTO>(coach);
            return coachDto;
        }

        /// <summary>
        /// Get the instance from DAO and then do the mapping
        /// </summary>
        /// <param name="username">the username of Coach to be found</param>
        /// <param name="password">the password of Coach to be found</param>
        /// <returns>A Coach DTO instance</returns>
        public CoachReadOnlyDTO? GetCoachByUsnmPass(string username, string password)
        {
            Coach? coach = null;
            try
            {
                coach = dao.GetCByUsnmPass(username, password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            CoachReadOnlyDTO coachDto = mapper.Map<CoachReadOnlyDTO>(coach);
            return coachDto;
        }

        /// <summary>
        /// Get the instances from DAO and then do the mapping into a List
        /// </summary>
        /// <returns>A List of Coach DTO's or empty list if there is none</returns>
        public List<CoachReadOnlyDTO> GetAllCoaches()
        {
            List<Coach> coaches = new List<Coach>();
            var coachesDto = new List<CoachReadOnlyDTO>();

            try
            {
                coaches =  dao.GetAllC();
            }
            catch(Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

            coachesDto = mapper.Map<List<CoachReadOnlyDTO>>(coaches);
            return coachesDto;
        }
    }
}
