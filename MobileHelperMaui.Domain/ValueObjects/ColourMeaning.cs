using MobileHelperMaui.Domain.Exceptions;
using MobileHelperMaui.Domain.Share;
using static MobileHelperMaui.Domain.Enums.ColourMeaning;

namespace MobileHelperMaui.Domain.ValueObjects
{
    public class ColourMeaning : ValueObject
    {
        static ColourMeaning()
        {
        }

        private ColourMeaning()
        {
        }

        private ColourMeaning(ColourMeaningType colourMeaningType, string explaination)
        {
            this.ColorType = colourMeaningType;
            this.Explaination = explaination;
        }

        public static ColourMeaning From(string explaination, ColourMeaningType colourMeaningType)
        {
            ColourMeaning ColourMeaning = new() { Explaination = explaination, ColorType = colourMeaningType };

            return !SupportedColourMeanings.Contains(ColourMeaning) ? throw new UnsupportedColourMeaningException(explaination) : ColourMeaning;
        }

        #region Voted Cases
        public static ColourMeaning BlackVoted => new(ColourMeaningType.Wanted,
            "Негативизм, неприятие отказ от удовольствия и агрессия заполнили все Ваше сознание и тело. Вы враждебно настроены и можете взорваться яростью в любую минуту. Вы близки к разрушению себя или отношений.");
        public static ColourMeaning RedVoted => new(ColourMeaningType.Wanted,
            "Сейчас Вы эмоционально возбуждены. Настроение приподнятое. Вы стремитесь к достижению, успеху. Вы наступаете, возможно излишне давите. Вы напористы, порой агрессивны.");
        public static ColourMeaning BlueVoted => new(ColourMeaningType.Wanted,
            "Вы стремитесь к согласию, доверию, пониманию, сочувствию. Сейчас Вы испытываете эмоциональный комфорт, спокойствие, мягкость, мечтательность. Вы расположены к общению с друзьями.");
        public static ColourMeaning PurpleVoted => new(ColourMeaningType.Wanted,
            "Вы флиртуете направо и налево, стремитесь завести хоть какую-нибудь сексуальную интрижку. Вы стремитесь понравиться, получить поддержку или комплимент. Настроение ровное, но не спокойное.");
        public static ColourMeaning YellowVoted => new(ColourMeaningType.Wanted,
            "Оптимизм переполняет Вашу душу и заставляет сердце стучать быстрее. Вы расслаблены и полны мечтами об удаче. Вы готовы к изменениям, к полному освобождению от отношений или обязательств.");
        public static ColourMeaning OrangeVoted => new(ColourMeaningType.Wanted,
            "Вы устали и стремитесь к отдыху и эмоциональной стабильности. Вы психологически устали и голодны по поддерживающим отношениям. Подспудно Вы чего-то боитесь и не чувствуете себя в безопасности. Вы нуждаетесь в чувственном удовлетворении.");
        public static ColourMeaning GreenVoted => new(ColourMeaningType.Wanted,
            "Вы уверены в себе, даже самоуверенны. Сейчас пик Вашей силы, самоуважения. Вы способны на многое и стремитесь захватить власть в общении. Взять верх над собеседниками. Возможно напротив, Вы заняли психологическую оборону.");
        public static ColourMeaning GrayVoted => new(ColourMeaningType.Wanted,
            "Вы сейчас в поисках плеча, на которое сможете опереться.Хотите спрятаться от всего тяжелого, что есть в Вашей жизни, обрести эмоциональный покой и пристанище. Вы мимикрируете и маскируете свои истинные чувства под маской деланного безразличия и безучастности.");

        #endregion

        #region Unvoted Cases

        public static ColourMeaning BlackUnvoted => new(ColourMeaningType.Unwanted,
            "Внешне Вы спокойны и уверены. Однако Вы просто загнали агрессию глубоко вовнутрь и перешли на рельсы отрицания и самобичевания.");
        public static ColourMeaning RedUnvoted => new(ColourMeaningType.Unwanted,
            "Вы постоянно раздражены и перевозбуждены. Вы в глубоком стрессе. Иногда Вы словно обессилены или даже утомлены.");
        public static ColourMeaning BlueUnvoted => new(ColourMeaningType.Unwanted,
            "Вы беспокойны. Возможно недавно произошел разрыв близких отношений. Вы одиноки и расстроены.");
        public static ColourMeaning PurpleUnvoted => new(ColourMeaningType.Unwanted,
            "Вы стремитесь быть незаметным и спрятаться от излишнего внимания. Скромность, контроль чувств и поведения присущи Вам именно сейчас.");
        public static ColourMeaning YellowUnvoted => new(ColourMeaningType.Unwanted,
            "Вы разочарованы вплоть до отчаяния. Вы недоверчивы и подозрительны. Вы мечетесь, эмоциональное состояние нестабильно: то подъем, то резкий спад.");
        public static ColourMeaning OrangeUnvoted => new(ColourMeaningType.Unwanted,
            "Вы как натянутая струна. Вы отрицаете все свои эмоциональные и физические потребности.  Вы бежите от слабости,ограничивая себя во всем. Вы нуждаетесь в чувственном удовлетворении.");
        public static ColourMeaning GreenUnvoted => new(ColourMeaningType.Unwanted,
            "Вы фрустрированы недостатком внимания и уважения со стороны партнера. Вы унижены, обижены, уязвлены и обесточены.  У Вас не осталось сил на сопротивление.");
        public static ColourMeaning GrayUnvoted => new(ColourMeaningType.Unwanted,
            "Вы проактивны как никогда. Вы целиком включены в ситуацию «здесь-и-сейчас». Вы контакты, в меру веселы и находчивы. У Вас есть цель и Вы обретаете уверенное спокойствие в завтрашнем дне. Вы словно обрели цель.");

        #endregion

        public string Explaination { get; private set; }
        public ColourMeaningType ColorType { get; private set; }

        public override string ToString()
        {
            return this.Explaination;
        }

        protected static IEnumerable<ColourMeaning> SupportedColourMeanings
        {
            get
            {
                #region Voted Cases
                yield return BlackVoted;
                yield return RedVoted;
                yield return BlueVoted;
                yield return PurpleVoted;
                yield return YellowVoted;
                yield return OrangeVoted;
                yield return GrayVoted;
                yield return GrayVoted;
                #endregion

                #region Unvoted Cases
                yield return BlackUnvoted;
                yield return RedUnvoted;
                yield return BlueUnvoted;
                yield return PurpleUnvoted;
                yield return YellowUnvoted;
                yield return OrangeUnvoted;
                yield return GrayUnvoted;
                yield return GrayUnvoted;
                #endregion
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Explaination;
        }
    }
}
