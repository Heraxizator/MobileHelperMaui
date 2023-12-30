namespace MobileHelperMaui.Application.Services
{
    public class PsyhosomaticService
    {
        public FolderHistory FolderHistory = new();
        public PsyhosomaticService() 
        {
            // Общая папка, которая включает в себя все папки
            Folder domain = new Folder("Психосоматика");

            // Алкоголизм и его причины
            Component alcoholism = new Folder("Алкоголизм");

            Component alcoholismA = new File("Не в состоянии с чем-то справиться." +
                " Жуткий страх. Желание уйти подальше от всех и всего. Нежелание находиться здесь.");

            Component alcoholismB = new File("Чувство тщетности, несоответствия. " +
                "Неприятие собственной личности.");

            alcoholism.AddRange(alcoholismA, alcoholismB);

            domain.Add(alcoholism);

            // Аллергия и её причины
            Component allergy = new Folder("Аллергия");

            Component allergyA = new File("Кого вы не выносите? Отрицание собственной силы.");

            Component allergyB = new File("Протест против чего-либо," +
                " который нет возможности выразить.");

            Component allergyC = new File("Часто бывает," +
                " что родители аллергика часто спорили и имели совершенно разные взгляды на жизнь.");

            allergy.AddRange(allergyA, allergyB, allergyC);

            domain.Add(allergy);

            // Аппендицит и его причины
            Component appendicitis = new Folder("Аппендицит");

            Component appendicitisA = new File("Страх. Страх жизни. Блокирование всего хорошего.");

            appendicitis.AddRange(appendicitisA);

            domain.Add(appendicitis);

            // Контрольная точка для файловой системы

            FolderMemento memento = domain.SaveState();

            FolderHistory.History.Push(memento);
        }

        public List<Component> GetFolders()
        {
            FolderMemento memento = FolderHistory.History.Peek();

            Folder domain = new ("Предметная область");

            domain.RestoreState(memento);

            return domain.GetComponents();
        }
    }

    #region Memento pattern

    public class FolderMemento
    {
        public string Name { get; set; }
        public List<Component> Components { get; set; }

        public FolderMemento(string name, List<Component> components)
        {
            this.Name = name;
            this.Components = components;
        }
    }

    public class FolderHistory
    {
        public Stack<FolderMemento> History { get; set; }
        public FolderHistory()
        {
            this.History = new Stack<FolderMemento>();
        }
    }

    #endregion

    #region Composite pattern
    public abstract class Component
    {
        protected string name;

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component)
        {

        }

        public virtual void AddRange(params Component[] items)
        {

        }

        public virtual void Remove(Component component)
        {

        }

        public override string ToString()
        {
            return this.name;
        }
    }

    internal class Folder : Component
    {
        private List<Component> components = new();

        public Folder(string name) : base(name)
        {

        }

        public List<Component> GetComponents()
        {
            return this.components;
        }

        public FolderMemento SaveState()
        {
            return new FolderMemento(this.name, this.components);
        }

        public void RestoreState(FolderMemento memento)
        {
            this.name = memento.Name;
            this.components = memento.Components;
        }

        public override void Add(Component component)
        {
            this.components.Add(component);
        }

        public override void AddRange(params Component[] items)
        {
            foreach (Component item in items)
            {
                this.components.Add(item);
            }
        }

        public override void Remove(Component component)
        {
            _ = this.components.Remove(component);
        }

        public override string ToString()
        {
            List<string> list = new();

            foreach (Component component in this.components)
            {
                list.Add(component.ToString());
            }

            return string.Join(", ", list.ToArray());
        }
    }

    internal class File : Component
    {
        public File(string name) : base(name)
        {

        }
    }

    #endregion
}
