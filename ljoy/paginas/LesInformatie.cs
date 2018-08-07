using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ljoy.paginas
{
	public class LesInformatie : ContentPage
	{
		public LesInformatie (Lessen.Les les)
		{
            Title = les.Naam;
			Content = new StackLayout {
				Children = {
                    new Label { Text = les.Tijd },
                    new Label { Text = les.Omschrijving },
                    new Label { Text = les.Docent }
                }
			};
		}
	}
}