namespace ElmiraApplication;

using Microsoft.Maui.Controls.PlatformConfiguration;
using QRCoder;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.Drawing;

public partial class MainPage : ContentPage
{
    string excelFilePath = @"C:\Users\Milestone\Desktop\qr\qr.xlsx";
    public MainPage()
    {
        InitializeComponent();
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
    }

    /* private async void OnGenerateClicked(object sender, EventArgs e)
     {
         // Obtenir les données des champs d'entrée
         string reference = RefText.Text;
         string produit = ProdText.Text;
         string prixUnitaire = PUText.Text;
         string montant = MontantText.Text;

         // Concaténer les données dans une chaîne
         string qrData = $"Référence: {reference}\nProduit: {produit}\nPrix Unitaire: {prixUnitaire}\nMontant: {montant}";

         // Générer le code QR
         QRCodeGenerator qrGenerator = new QRCodeGenerator();
         QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrData, QRCodeGenerator.ECCLevel.L);
         PngByteQRCode qRCode = new PngByteQRCode(qrCodeData);
         byte[] qrCodeBytes = qRCode.GetGraphic(20);

         // Afficher le code QR dans l'image
         QrCodeImage.Source = ImageSource.FromStream(() => new MemoryStream(qrCodeBytes));

         // Enregistrer le QR code dans un fichier Excel
         await SaveQRCodeToExcelAsync(qrCodeBytes, reference, produit, prixUnitaire, montant);
     }
 */

    /*private async Task SaveQRCodeToExcelAsync(byte[] qrCodeBytes, string reference, string produit, string prixUnitaire, string montant)
    {
        // Emplacement où vous souhaitez enregistrer le fichier Excel
        string excelFilePath = @"C:\Users\Milestone\Desktop\qr\qr.xlsx";

        // Créer un nouveau fichier Excel
        FileInfo newFile = new FileInfo(excelFilePath);
        using (ExcelPackage package = new ExcelPackage(newFile))
        {
            // Ajouter une nouvelle feuille au fichier Excel
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("QRCodeSheet");
            // Ajout du titre
            string title = "Liste des Produits";
            worksheet.Cells["A1:D1"].Merge = true; // Fusionner les cellules pour le titre
            worksheet.Cells["A1"].Value = title; // Écrire le titre dans la cellule fusionnée
            worksheet.Cells["A1:D1"].Style.Font.Bold = true; // Mettre en gras
            worksheet.Cells["A1:D1"].Style.Font.Color.SetColor(ColorTranslator.FromHtml("#ff7900")); // Couleur de la police #ff7900
            worksheet.Cells["A1:D1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Centrer le texte
                                                                                                  // Ajout des en-têtes de colonne
            worksheet.Cells[2, 1].Value = "Réference";
            worksheet.Cells[2, 2].Value = "Produit";
            worksheet.Cells[2, 3].Value = "Prix unitaire";
            worksheet.Cells[2, 4].Value = "Montant";
            worksheet.Cells[2, 5].Value = "QR code ";
            // Mise en forme des en-têtes de colonne
            using (var range = worksheet.Cells["A2:E2"])
            {
                range.Style.Font.Bold = true; // Mettre en gras
                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                range.Style.Fill.BackgroundColor.SetColor(ColorTranslator.FromHtml("#ff7900")); // Couleur de fond #ff7900
                range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center; // Centrer le texte
            }
            // Ajuster automatiquement la largeur des colonnes selon le contenu
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            // Ajouter les valeurs sous les cellules spécifiques
            worksheet.Cells[3, 1].Value = reference;
            worksheet.Cells[3, 2].Value = produit;
            worksheet.Cells[3, 3].Value = prixUnitaire;
            worksheet.Cells[3, 4].Value = montant;

            // Insérer l'image du QR code dans une cellule de la feuille Excel
            ExcelPicture qrCodePicture = worksheet.Drawings.AddPicture("QRCode", new MemoryStream(qrCodeBytes));
            qrCodePicture.SetPosition(2, 0, 4, 0);
            //var qrCodePosition = worksheet.Cells["E3"]; // Cellule où vous souhaitez insérer le QR code
            *//* qrCodePicture.SetPosition(qrCodePosition.Start.Row, qrCodePosition.Start.Column, 0, 0);*//* // Positionner l'image dans la cellule
            qrCodePicture.SetSize(100, 100); // Ajustez la taille de l'image selon vos besoins
           
           
            // Sauvegarder les modifications dans le fichier Excel
            await package.SaveAsync();
        }
    }
*/

    private async void Button_Clicked(object sender, EventArgs e)
    {
        // Réinitialiser le contenu du Label lorsque le bouton est cliqué
        qrCodeLabel.Text = "";
        string qrCodeText = await QRCodeScanner.ScanQRCodeAsync();

        if (!string.IsNullOrEmpty(qrCodeText))
        {
            qrCodeLabel.Text = qrCodeText;
            //await DisplayAlert("QR Code", qrCodeText, "OK");
        }
        else
        {
            qrCodeLabel.Text = "Aucun code QR n'a été détecté.";
            //await DisplayAlert("QR Code", "Aucun code QR n'a été détecté.", "OK");
        }
        
    }


}
