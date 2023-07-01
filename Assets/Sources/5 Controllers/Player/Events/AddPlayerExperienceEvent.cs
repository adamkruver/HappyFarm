using HappyFarm.UseCases.Sources._2_Infrastructure.Interfaces;

namespace HappyFarm.Controllers.Sources._5_Controllers.Player.Events
{
    public class AddPlayerExperienceEvent : IControllerEvent
    {
        public AddPlayerExperienceEvent(int experience)
        {
            Experience = experience;
        }

        public int Experience { get; }
    }
}