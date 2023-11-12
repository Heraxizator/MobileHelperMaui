using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Windows.Input;

namespace MobileHelper.ViewModels.TestViewModels
{
    public class TestViewModel : BaseViewModel
    {

        private const string firstInstruction = "Выберите приятный вам цвет";
        private const string secondInstruction = "А теперь выберите неприятный вам цвет";
        private string[] positiveValues { get; set; }
        private string[] negativeValues { get; set; }
        private Color[] colorValues { get; set; }
        private string[] nameValues { get; set; }
        private int firstId { get; set; }
        private int secondId { get; set; }
        public ICommand Restart { get; set; }
        public ICommand BlackHandler { get; set; }
        public ICommand RedHandler { get; set; }
        public ICommand BlueHandler { get; set; }
        public ICommand PurpleHandler { get; set; }
        public ICommand YellowHandler { get; set; }
        public ICommand BrownHandler { get; set; }
        public ICommand GreenHandler { get; set; }
        public ICommand GrayHandler { get; set; }
        private string currentInstruction { get; set; }
        private Color firstColor { get; set; }
        private Color secondColor { get; set; }
        private string firstName { get; set; }
        private string secondName { get; set; }
        private string firstResult { get; set; }
        private string secondResult { get; set; }
        private bool isStart { get; set; }
        private bool isFinish { get; set; }
        private bool isBlack { get; set; }
        private bool isRed { get; set; }
        private bool isBlue { get; set; }
        private bool isPurple { get; set; }
        private bool isYellow { get; set; }
        private bool isBrown { get; set; }
        private bool isGreen { get; set; }
        private bool isGray { get; set; }
        public TestViewModel()
        {

        }

        public TestViewModel(INavigation navigation)
        {
            this.Title = "Тест";
            this.Navigation = navigation;

            this.Finish = new Command(ToFinish);
            this.Restart = new Command(ToRestart);
            this.BlackHandler = new Command(ToBlackHandler);
            this.RedHandler = new Command(ToRedHandler);
            this.BlueHandler = new Command(ToBlueHandler);
            this.PurpleHandler = new Command(ToPurpleHandler);
            this.YellowHandler = new Command(ToYellowCommand);
            this.BrownHandler = new Command(ToBrownHandler);
            this.GreenHandler = new Command(ToGreenHandler);
            this.GrayHandler = new Command(ToGrayHandler);

            this.positiveValues = new string[8] {
                "Негативизм, неприятие отказ от удовольствия и агрессия заполнили все Ваше сознание и тело. Вы враждебно настроены и можете взорваться яростью в любую минуту. Вы близки к разрушению себя или отношений.",
                "Сейчас Вы эмоционально возбуждены. Настроение приподнятое. Вы стремитесь к достижению, успеху. Вы наступаете, возможно излишне давите. Вы напористы, порой агрессивны.",
                "Вы стремитесь к согласию, доверию, пониманию, сочувствию. Сейчас Вы испытываете эмоциональный комфорт, спокойствие, мягкость, мечтательность. Вы расположены к общению с друзьями.",
                "Вы флиртуете направо и налево, стремитесь завести хоть какую-нибудь сексуальную интрижку. Вы стремитесь понравиться, получить поддержку или комплимент. Настроение ровное, но не спокойное.",
                "Оптимизм переполняет Вашу душу и заставляет сердце стучать быстрее. Вы расслаблены и полны мечтами об удаче. Вы готовы к изменениям, к полному освобождению от отношений или обязательств.",
                "Вы устали и стремитесь к отдыху и эмоциональной стабильности. Вы психологически устали и голодны по поддерживающим отношениям. Подспудно Вы чего-то боитесь и не чувствуете себя в безопасности. Вы нуждаетесь в чувственном удовлетворении.",
                "Вы уверены в себе, даже самоуверенны. Сейчас пик Вашей силы, самоуважения. Вы способны на многое и стремитесь захватить власть в общении. Взять верх над собеседниками. Возможно напротив, Вы заняли психологическую оборону.",
                "Вы сейчас в поисках плеча, на которое сможете опереться.Хотите спрятаться от всего тяжелого, что есть в Вашей жизни, обрести эмоциональный покой и пристанище. Вы мимикрируете и маскируете свои истинные чувства под маской деланного безразличия и безучастности."
            };

            this.negativeValues = new string[8] {
                 "Внешне Вы спокойны и уверены. Однако Вы просто загнали агрессию глубоко вовнутрь и перешли на рельсы отрицания и самобичевания.",
                 "Вы постоянно раздражены и перевозбуждены. Вы в глубоком стрессе. Иногда Вы словно обессилены или даже утомлены.",
                 "Вы беспокойны. Возможно недавно произошел разрыв близких отношений. Вы одиноки и расстроены.",
                 "Вы стремитесь быть незаметным и спрятаться от излишнего внимания. Скромность, контроль чувств и поведения присущи Вам именно сейчас.",
                 "Вы разочарованы вплоть до отчаяния. Вы недоверчивы и подозрительны. Вы мечетесь, эмоциональное состояние нестабильно: то подъем, то резкий спад.",
                 "Вы как натянутая струна. Вы отрицаете все свои эмоциональные и физические потребности.  Вы бежите от слабости,ограничивая себя во всем.",
                 "Вы фрустрированы недостатком внимания и уважения со стороны партнера. Вы унижены, обижены, уязвлены и обесточены.  У Вас не осталось сил на сопротивление.",
                 "Вы проактивны как никогда. Вы целиком включены в ситуацию «здесь-и-сейчас». Вы контакты, в меру веселы и находчивы. У Вас есть цель и Вы обретаете уверенное спокойствие в завтрашнем дне. Вы словно обрели цель."
            };

            this.colorValues = new Color[8]
            {
                Colors.Black,
                Colors.Red,
                Colors.Blue,
                Colors.Purple,
                Colors.Yellow,
                Colors.Orange,
                Colors.Green,
                Colors.Gray,
            };

            this.nameValues = new string[8]
            {
                "Чёрный", "Красный", "Синий", "Фиолетовый", "Жёлтый", "Оранжевый", "Зелёный", "Серый"
            };

            Init();
        }

        private void ToRestart(object obj)
        {
            Init();
        }

        private void Init()
        {
            this.CurrentInstruction = firstInstruction;
            this.IsBlack = true;
            this.IsRed = true;
            this.IsBlue = true;
            this.IsPurple = true;
            this.IsYellow = true;
            this.IsBrown = true;
            this.IsGreen = true;
            this.IsGray = true;

            this.firstId = -1;
            this.secondId = -1;

            this.IsStart = true;
            this.IsFinish = false;
        }

        private void SaveResult(int id)
        {
            if (this.firstId == -1)
            {
                this.firstId = id;
                this.CurrentInstruction = secondInstruction;
                this.FirstResult = this.positiveValues[this.firstId];
                this.FirstColor = this.colorValues[this.firstId];
                this.FirstName = this.nameValues[this.firstId];
            }

            else if (this.secondId == -1)
            {
                this.secondId = id;
                this.SecondResult = this.negativeValues[this.secondId];
                this.SecondColor = this.colorValues[this.secondId];
                this.SecondName = this.nameValues[this.secondId];
                this.IsStart = false;
                this.IsFinish = true;
            }
        }

        private void ToGrayHandler(object obj)
        {
            this.IsGray = false;
            SaveResult(7);
        }

        private void ToGreenHandler(object obj)
        {
            this.IsGreen = false;
            SaveResult(6);
        }

        private void ToBrownHandler(object obj)
        {
            this.IsBrown = false;
            SaveResult(5);
        }

        private void ToYellowCommand(object obj)
        {
            this.IsYellow = false;
            SaveResult(4);
        }

        private void ToPurpleHandler(object obj)
        {
            this.IsPurple = false;
            SaveResult(3);
        }

        private void ToBlueHandler(object obj)
        {
            this.IsBlue = false;
            SaveResult(2);
        }

        private void ToRedHandler(object obj)
        {
            this.IsRed = false;
            SaveResult(1);
        }

        private void ToBlackHandler(object obj)
        {
            this.IsBlack = false;
            SaveResult(0);

        }

        public string CurrentInstruction
        {
            get => this.currentInstruction;
            set
            {
                if (this.currentInstruction != value)
                {
                    this.currentInstruction = value;
                    OnPropertyChanged(nameof(this.CurrentInstruction));
                }
            }
        }

        public string FirstResult
        {
            get => this.firstResult;
            set
            {
                if (this.firstResult != value)
                {
                    this.firstResult = value;
                    OnPropertyChanged(nameof(this.FirstResult));
                }
            }
        }

        public string SecondResult
        {
            get => this.secondResult;
            set
            {
                if (this.secondResult != value)
                {
                    this.secondResult = value;
                    OnPropertyChanged(nameof(this.SecondResult));
                }
            }
        }

        public Color FirstColor
        {
            get => this.firstColor;
            set
            {
                if (this.firstColor != value)
                {
                    this.firstColor = value;
                    OnPropertyChanged(nameof(this.FirstColor));
                }
            }
        }

        public Color SecondColor
        {
            get => this.secondColor;
            set
            {
                if (this.secondColor != value)
                {
                    this.secondColor = value;
                    OnPropertyChanged(nameof(this.SecondColor));
                }
            }
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                if (this.firstName != value)
                {
                    this.firstName = value;
                    OnPropertyChanged(nameof(this.FirstName));
                }
            }
        }

        public string SecondName
        {
            get => this.secondName;
            set
            {
                if (this.secondName != value)
                {
                    this.secondName = value;
                    OnPropertyChanged(nameof(this.SecondName));
                }
            }
        }

        public bool IsStart
        {
            get => this.isStart;
            set
            {
                if (this.isStart != value)
                {
                    this.isStart = value;
                    OnPropertyChanged(nameof(this.IsStart));
                }
            }
        }
        public bool IsFinish
        {
            get => this.isFinish;
            set
            {
                if (this.isFinish != value)
                {
                    this.isFinish = value;
                    OnPropertyChanged(nameof(this.IsFinish));
                }
            }
        }

        public bool IsBlack
        {
            get => this.isBlack;
            set
            {
                if (this.isBlack != value)
                {
                    this.isBlack = value;
                    OnPropertyChanged(nameof(this.IsBlack));
                }
            }
        }

        public bool IsRed
        {
            get => this.isRed;
            set
            {
                if (this.isRed != value)
                {
                    this.isRed = value;
                    OnPropertyChanged(nameof(this.IsRed));
                }
            }
        }

        public bool IsBlue
        {
            get => this.isBlue;
            set
            {
                if (this.isBlue != value)
                {
                    this.isBlue = value;
                    OnPropertyChanged(nameof(this.IsBlue));
                }
            }
        }

        public bool IsPurple
        {
            get => this.isPurple;
            set
            {
                if (this.isPurple != value)
                {
                    this.isPurple = value;
                    OnPropertyChanged(nameof(this.IsPurple));
                }
            }
        }

        public bool IsYellow
        {
            get => this.isYellow;
            set
            {
                if (this.isYellow != value)
                {
                    this.isYellow = value;
                    OnPropertyChanged(nameof(this.IsYellow));
                }
            }
        }

        public bool IsBrown
        {
            get => this.isBrown;
            set
            {
                if (this.isBrown != value)
                {
                    this.isBrown = value;
                    OnPropertyChanged(nameof(this.IsBrown));
                }
            }
        }

        public bool IsGreen
        {
            get => this.isGreen;
            set
            {
                if (this.isGreen != value)
                {
                    this.isGreen = value;
                    OnPropertyChanged(nameof(this.IsGreen));
                }
            }
        }

        public bool IsGray
        {
            get => this.isGray;
            set
            {
                if (this.isGray != value)
                {
                    this.isGray = value;
                    OnPropertyChanged(nameof(this.IsGray));
                }
            }
        }
    }
}
