using ljoy.entiteiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ljoy.paginas
{
	public class NieuwsInformatie : ContentPage
	{
        public NieuwsInformatie (NieuwsEntiteit nieuws)
		{
            Title = nieuws.titel;
			Content = new StackLayout {
				Children = {
                    new Label { Text = nieuws.tekst }
                }
			};
		}
	}
}