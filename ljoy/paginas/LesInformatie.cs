using ljoy.entiteiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ljoy.paginas
{
	public class LesInformatie : ContentPage
	{
		public LesInformatie (Les les)
		{
            Title = les.naam;
			Content = new StackLayout {
				Children = {
                    new Label { Text = les.tijdstip },
                    new Label { Text = les.omschrijving },
                    new Label { Text = les.docent },
                    new Label { Text = les.dag },
                    new Label { Text = les.inschrijfbaar.ToString()}
                }
			};
		}
	}
}