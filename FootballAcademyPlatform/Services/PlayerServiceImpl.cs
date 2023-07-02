using AutoMapper;
using FootballAcademyPlatform.DAO;
using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Models;


namespace FootballAcademyPlatform.Services
{
    /// <summary>
    /// A  Player Service layer that communicates with the controllers by getting
    /// Player DTO's and then pass simple model instances to the DAO layer for the CRUD actions
    /// </summary>
    public class PlayerServiceImpl : IPlayerService
    {
        private readonly IPlayerDAO playerDAO;
        private readonly IMapper mapper;

        public PlayerServiceImpl(IPlayerDAO playerDAO, IMapper mapper)
        {
            this.playerDAO = playerDAO;
            this.mapper = mapper;
        }

        /// <summary>
        /// mapping the DTO to Player instance and pass it to the DAO for the insert
        /// </summary>
        /// <param name="pDto">The DTO for the insert action</param>
        public void InsertPLayer(PlayerCreateDTO? pDto)
        {
            if (pDto == null) return;

            Player? player = mapper.Map<Player>(pDto);
            try
            {
                playerDAO.InsertP(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// mapping the DTO to Player instance and pass it to the DAO for the update
        /// </summary>
        /// <param name="pDto">The DTO for the update action</param>
        public void UpdatePlayer(PlayerUpdateDTO? pDto)
        {
            if (pDto == null) return;

            Player? player = mapper.Map<Player>(pDto);
            try
            {
                playerDAO.UpdateP(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// mapping the DTO to Player instance and pass it to the DAO for a more specific update
        /// </summary>
        /// <param name="coachPlayerUpdate">The DTO for the update action</param>
        public void UpdateCoachPlayer(CoachPlayerUpdateDTO coachPlayerUpdate)
        {
            if (coachPlayerUpdate == null) return;

            Player? player = mapper.Map<Player>(coachPlayerUpdate);
            try
            {
                playerDAO.UpdateCoachP(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Get the Player instance to be deleted by the id and then
        /// mapping the DTO to Player instance and pass it to the DAO for the delete
        /// </summary>
        /// <param name="id">the Player id to found and deleted by the DAO</param>
        /// <returns>The deleted Player instance</returns>
        public PlayerReadOnlyDTO? DeletePlayer(int id)
        {
            Player? player = null;
            PlayerReadOnlyDTO? deletedPlayer = null;

            try
            {
                player = playerDAO.GetPById(id);
                deletedPlayer = mapper.Map<PlayerReadOnlyDTO>(player);
                if (player is null) return null;
                playerDAO.DeleteP(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            return deletedPlayer;
        }

        /// <summary>
        /// Get the instance from DAO and then do the mapping
        /// </summary>
        /// <param name="id">the id of Player to be found</param>
        /// <returns>A Player DTO instance</returns>
        public PlayerReadOnlyDTO? GetPlayerById(int id)
        {
            Player? player = null;
            try
            {
                player = playerDAO.GetPById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            PlayerReadOnlyDTO? playerDto = mapper.Map<PlayerReadOnlyDTO>(player);
            return playerDto;
        }

        /// <summary>
        /// Get the instance from DAO and then do the mapping
        /// </summary>
        /// <param name="email">the email of Player to be found</param>
        /// <returns>A Player DTO instance</returns>
        public PlayerReadOnlyDTO? GetPlayerByEmail(string email)
        {
            Player? player = null;
            try
            {
                player = playerDAO.GetPByEmail(email);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            PlayerReadOnlyDTO? playerDto = mapper.Map<PlayerReadOnlyDTO>(player);
            return playerDto;
        }

        /// <summary>
        /// Get the instances from DAO and then do the mapping into a List
        /// </summary>
        /// <returns>A List of Player DTO's or empty list if there is none</returns>
        public List<PlayerReadOnlyDTO> GetAllPlayers()
        {
            List<Player> players = new List<Player>();
            var playersDto = new List<PlayerReadOnlyDTO>();

            try
            {
                players = playerDAO.GetAllP();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            playersDto = mapper.Map<List<PlayerReadOnlyDTO>>(players);
            return playersDto;
        }

        
    }
}
