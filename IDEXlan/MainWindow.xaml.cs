using IDEXlan.Expresiones;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;


namespace IDEXlan
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string rutaArchivoActual;
        string[] tokens = new string[0];

        public MainWindow()
        {
            InitializeComponent();
            RegistrarEventos();
            rutaArchivoActual = string.Empty;
        }

        private void RegistrarEventos()
        {
            menuArchivoAbrir.Click += (sender, args) => 
            {
                OpenFileDialog abrir = new OpenFileDialog
                {
                    Title = "Abrir archivo xlang",
                    Filter = "Archivo de codigo xlang|*.xlang"
                };
                var res = abrir.ShowDialog();
                if(res == true)
                {
                    rutaArchivoActual =  abrir.FileName;
                    textEditor.AppendText(File.ReadAllText(rutaArchivoActual));
                }
                    
            };

            ExpresionesReg reg = new ExpresionesReg();

            menuArchivoGuardar.Click += GuardarArchivo;
            toolGuardar.Click += GuardarArchivo;
                
            textEditor.TextChanged += (sender, args) => { lblLineas.Content = $"Numero de lineas: {textEditor.LineCount}"; };
            toolTokens.Click += Tookens;

            List<TablaSimbolos> simbolos = new List<TablaSimbolos>();
            toolsTabla.Click += (sender, args) =>
            {
                simbolos.Clear();
                if (tokens.Length > 0 || tokens.Equals(null)) 
                {
                    foreach (var item in tokens)
                    {
                        simbolos.Add(new TablaSimbolos
                        {
                            Simbolo = item,
                            Definicion = reg.ConvertirToken(item),
                            Comentario = ""
                        });
                    }
                    tablaSimbolos.ItemsSource = null;
                    tablaSimbolos.ItemsSource = simbolos;
                }
                else
                {
                    MessageBox.Show("Antes de generar la tabla de tokens genera los tokens", "Error, no se han generado tokens", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            };
            menuAcerca.Click += delegate
            {
                new AcercaDe() { Owner= this }.Show();
            };
            toolNuevo.Click += (sender, args) =>
            {
                if (rutaArchivoActual != string.Empty || textEditor.Text != string.Empty)
                {
                    MessageBoxResult respuesta = MessageBox.Show( "¿Deseas guardar el archivo existente?", "Antes de crear nuevo", MessageBoxButton.YesNoCancel);
                    switch (respuesta)
                    {
                        case MessageBoxResult.Yes:
                            GuardarArchivoMet();
                            break;
                        case MessageBoxResult.No:
                            rutaArchivoActual = string.Empty;
                            textEditor.Text = string.Empty;
                            break;
                        case MessageBoxResult.Cancel:
                            break;
                    }
                }
            };
            menuArchivoCerrar.Click += (sender, args) => { this.Close(); };

        }

        private void Tookens(object sender, RoutedEventArgs e)
        {
            lbl_salida.Text = "";
            List<string> tokensLista = new List<string>();
            if (textEditor.Text != string.Empty)
            {
                tokens = textEditor.Text.Split(' ');
                foreach (var item in tokens)
                {
                    if (item.Contains("\n"))
                    {
                        string[] temp = item.Split('\n');
                        foreach (var tempItem in temp)
                        {
                            if (tempItem.Contains("\r"))
                               tokensLista.Add(tempItem.Substring(0, tempItem.Length - 1));
                            else
                                tokensLista.Add(tempItem);
                        }
                    }
                    else
                    {
                        tokensLista.Add(item);
                    }
                }
                tokens = tokensLista.ToArray();
                foreach (var item in tokens)
                    lbl_salida.AppendText(item + "\n");
                    
            }
            else
            {
                MessageBox.Show("No hay datos en el archivo, abre uno o crealo", "Importante");
            }
        }

        private void GuardarArchivo(object sender, RoutedEventArgs e)
        {
            GuardarArchivoMet();
        }

        private void GuardarArchivoMet()
        {
            if (rutaArchivoActual != string.Empty)
            {
                File.WriteAllText(rutaArchivoActual, textEditor.Text);
                MessageBox.Show($"El documento ha sido guardado exitosamente en:\n{rutaArchivoActual}", "¡Guardado con exito!");
            }
            else if ((rutaArchivoActual == string.Empty) && (textEditor.Text != string.Empty))
            {
                SaveFileDialog save = new SaveFileDialog
                {
                    Filter = "Archivo de codigo xlang|*.xlang"
                };
                var res = save.ShowDialog();
                if (res == true)
                {
                    rutaArchivoActual = save.FileName;
                    File.WriteAllText(rutaArchivoActual, textEditor.Text);
                    MessageBox.Show($"El documento ha sido guardado exitosamente en:\n{rutaArchivoActual}", "¡Guardado con exito!");
                }
            }
            else
            {
                MessageBox.Show("No se ha abierto un archivo de xlang aun", "Error");
            }
        }
    }
}
