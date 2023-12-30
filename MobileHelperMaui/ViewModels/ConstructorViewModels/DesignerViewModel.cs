using MobileHelper.Models.Tables;
using MobileHelperMaui.Services;
using System.Windows.Input;

namespace MobileHelper.ViewModels.ConstructorViewModels
{
    public class DesignerViewModel : BaseViewModel
    {
        public new INavigation Navigation { get; set; }
        public ICommand ExecuteTechnique { get; set; }
        public ICommand OpenCamera { get; set; }
        public ICommand OpenGallery { get; set; }
        private string _name_string { get; set; }
        private string _describtion_string { get; set; }
        private string _theme_string { get; set; }
        private string _author_string { get; set; }
        private string _algorithm_string { get; set; }
        private string _path_string { get; set; }
        private string _aim_string { get; set; }
        private int currentId { get; set; }
        public DesignerViewModel()
        {

        }
        public DesignerViewModel(INavigation navigation, int id)
        {
            this.currentId = id;

            this.Path = "technique.png";

            this.Title = "Конструктор";

            this.Navigation = navigation;

            this.OpenCamera = new Command(ToOpenCamera);

            this.OpenGallery = new Command(ToOpenGallery);

            InitAsync();
        }

        private async void InitAsync()
        {
            if (this.currentId != -1)
            {
                TechniqueDB current_item = await Manager.GetTechniqueById(this.currentId);

                this.Aim = "Изменить";

                this.Name = current_item.Title;

                this.Description = current_item.Subtitle;

                this.Theme = current_item.Theme;

                this.Author = current_item.Theme;

                this.Algorithm = current_item.Algorithm;

                this.Path = current_item.Image;

                this.ExecuteTechnique = new Command(ToChangeTechnique);
            }

            else
            {
                this.Aim = "Добавить";

                this.ExecuteTechnique = new Command(ToAddTechnique);
            }
        }

        private async void ToOpenCamera(object obj)
        {
            if (!MediaPicker.IsCaptureSupported)
            {
                this.DialogService.ShowAsync("Ошибка", "Камера не поддерживается на вашем устройстве");
                return;
            }

            try
            {
                FileResult photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    this.Path = photo.FullPath;
                }
            }

            catch (FeatureNotSupportedException)
            {
                this.DialogService.ShowAsync("Ошибка", "Камера не поддерживается на вашем устройстве");
            }
            catch (PermissionException)
            {
                this.DialogService.ShowAsync("Ошибка", "Приложению не предоставлено разрешение на использование камеры");
            }
            catch (Exception)
            {
                this.DialogService.ShowAsync("Ошибка", "Не удалось применить камеру. Напишите в техническую поддержку");
            }
        }

        private async void ToOpenGallery(object obj)
        {
            try
            {
                FileResult photo = await MediaPicker.PickPhotoAsync();

                if (photo != null)
                {
                    this.Path = photo.FullPath;
                }
            }

            catch (FeatureNotSupportedException)
            {
                this.DialogService.ShowAsync("Ошибка", "Галерея не поддерживается на вашем устройстве");
            }
            catch (PermissionException)
            {
                this.DialogService.ShowAsync("Ошибка", "Приложению не предоставлено разрешение на использование галереи");
            }
            catch (Exception)
            {
                this.DialogService.ShowAsync("Ошибка", "Не удалось применить галерею. Напишите в техническую поддержку");
            }
        }

        [Obsolete]
        private void ToChangeTechnique(object obj)
        {
            TechniqueDB item = new()
            {
                Id = this.currentId,
                Title = this.Name,
                Subtitle = this.Description,
                Theme = this.Theme,
                Author = this.Author,
                Algorithm = this.Algorithm,
                Image = this.Path
            };

            bool result = Manager.UpdateTechnique(item);

            if (!result)
            {
                this.DialogService.ShowAsync("Ошибка", "Не удалось изменить технику");
            }

            else
            {
                try
                {
                    MessagingCenter.Send<object, TechniqueDB>(this, "change", item);
                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                _ = this.Navigation.PopToRootAsync(false);
            }
        }

        [Obsolete]
        private async void ToAddTechnique(object obj)
        {
            if (!string.IsNullOrEmpty(this.Name) && !string.IsNullOrEmpty(this.Description) && !string.IsNullOrEmpty(this.Theme)
                && !string.IsNullOrEmpty(this.Author) && !string.IsNullOrEmpty(this.Algorithm))
            {
                int count = await Manager.CountTechniques();

                string date = DateTime.Now.ToString().Split(' ').First();

                TechniqueBuilder builder = new();

                TechniqueDB technique = builder.SetIdentifier(count + 1)
                    .SetTitle(this.Name)
                    .SetSubtitle(this.Description)
                    .SetTheme(this.Theme)
                    .SetImage(this.Path)
                    .SetAuthor(this.Author)
                    .SetAlgorithm(this.Algorithm)
                    .SetDate(date)
                    .Build();

                bool result = Manager.AddTechnique(technique);

                if (!result)
                {
                    this.DialogService.ShowAsync("Ошибка", "Не удалось добавить технику");
                }

                else
                {
                    MessagingCenter.Send<object, TechniqueDB>(this, "add", technique);

                    _ = this.Navigation.PopAsync(false);
                }
            }

            else
            {
                this.DialogService.ShowAsync("Ошибка", "Необходимо заполнить все поля");
            }
        }

        #region Fluent Builder
        public class TechniqueBuilder
        {
            private readonly TechniqueDB techniqueDB;

            public TechniqueBuilder()
            {
                this.techniqueDB = new TechniqueDB();
            }

            public TechniqueBuilder SetIdentifier(int identifier)
            {
                this.techniqueDB.Id = identifier;
                return this;
            }

            public TechniqueBuilder SetDate(string date)
            {
                this.techniqueDB.Date = date;
                return this;
            }
            public TechniqueBuilder SetTitle(string title)
            {
                this.techniqueDB.Title = title;
                return this;
            }
            public TechniqueBuilder SetSubtitle(string subtitle)
            {
                this.techniqueDB.Subtitle = subtitle;
                return this;
            }

            public TechniqueBuilder SetTheme(string theme)
            {
                this.techniqueDB.Theme = theme;
                return this;
            }

            public TechniqueBuilder SetAuthor(string author)
            {
                this.techniqueDB.Author = author;
                return this;
            }

            public TechniqueBuilder SetAlgorithm(string algorithm)
            {
                this.techniqueDB.Algorithm = algorithm;
                return this;
            }

            public TechniqueBuilder SetImage(string image)
            {
                this.techniqueDB.Image = image;
                return this;
            }

            public TechniqueBuilder IsVisible
            {
                get
                {
                    this.techniqueDB.Removed = false;
                    return this;
                }
            }
            public TechniqueDB Build()
            {
                return this.techniqueDB;
            }
        }

        #endregion

        #region Public Properties

        public string Name
        {
            get => this._name_string;
            set
            {
                if (this._name_string != value)
                {
                    this._name_string = value;
                    OnPropertyChanged(nameof(this.Name));
                }
            }
        }

        public string Description
        {
            get => this._describtion_string;
            set
            {
                if (this._describtion_string != value)
                {
                    this._describtion_string = value;
                    OnPropertyChanged(nameof(this.Description));
                }
            }
        }

        public string Theme
        {
            get => this._theme_string;
            set
            {
                if (this._theme_string != value)
                {
                    this._theme_string = value;
                    OnPropertyChanged(nameof(this.Theme));
                }
            }
        }

        public string Author
        {
            get => this._author_string;
            set
            {
                if (this._author_string != value)
                {
                    this._author_string = value;
                    OnPropertyChanged(nameof(this.Author));
                }
            }
        }

        public string Algorithm
        {
            get => this._algorithm_string;
            set
            {
                if (this._author_string != value)
                {
                    this._algorithm_string = value;
                    OnPropertyChanged(nameof(this.Algorithm));
                }
            }
        }

        public string Path
        {
            get => this._path_string;
            set
            {
                if (this._path_string != value)
                {
                    this._path_string = value;
                    OnPropertyChanged(nameof(this.Path));
                }
            }
        }

        public string Aim
        {
            get => this._aim_string;
            set
            {
                if (this._aim_string != value)
                {
                    this._aim_string = value;
                    OnPropertyChanged(nameof(this.Aim));
                }
            }
        }

        #endregion
    }
}
