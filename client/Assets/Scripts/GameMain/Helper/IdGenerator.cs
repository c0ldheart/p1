namespace GameUtils
{
    public class IdGenerator : GlobalSingleton<IdGenerator>
    {
        private int m_curID = 2;
        public int GetNextID()
        {
            return m_curID++;
        }
    }
}