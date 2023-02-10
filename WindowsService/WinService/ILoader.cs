namespace WinService
{
    internal interface ILoader<T>
    {
        void LoadData();
        T GetLoadedData();
    }
}
