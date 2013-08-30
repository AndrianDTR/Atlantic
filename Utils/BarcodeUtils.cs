using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AY.Utils
{
	public class Barcode
	{
		public static string EAN8(string chaine)
		{
			int i;
			double checksum;
			string CodeBarre = "";

			checksum = 0;
			if (chaine.Length == 7)
			{
				for (i = 1; i <= 7; i++)
				{
					int L1 = Convert.ToChar(chaine.Substring(i - 1, 1));

					if ((L1 < 48) || (L1 > 57))
					{
						i = 0;
						break;
					}
				}

				if (i == 8)
				{
					for (i = 7; i > 0; i = i - 2)
					{
						checksum = checksum + Convert.ToInt32(chaine.Substring(i - 1, 1));
					}

					checksum = checksum * 3;

					for (i = 6; i > 0; i = i - 2)
					{
						checksum = checksum + Convert.ToInt32(chaine.Substring(i - 1, 1));
					}

					chaine = chaine + (10 - checksum % 10) % 10;
					CodeBarre = ":";

					for (i = 1; i <= 4; i++)
					{
						CodeBarre = CodeBarre + Convert.ToChar(65 + Convert.ToInt32(chaine.Substring(i - 1, 1)));
					}

					CodeBarre = CodeBarre + "*";
					for (i = 5; i <= 8; i++)
					{
						CodeBarre = CodeBarre + Convert.ToChar(97 + Convert.ToInt32(chaine.Substring(i - 1, 1)));
					}

					CodeBarre = CodeBarre + "+";
				}
			}

			return CodeBarre;
		}

		public static object EAN13(string chaine)
		{
			object functionReturnValue = null;
			int i;
			int checksum = 0;
			int first;
			string CodeBarre;
			bool tableA;
			functionReturnValue = "";

			if (chaine.Length == 12)
			{
				for (i = 1; i <= 12; i++)
				{
					int L1 = Convert.ToChar(chaine.Substring(i - 1, 1));
					if (L1 < 48 || L1 > 57)
					{
						i = 0;
						break;
					}
				}

				if (i == 13)
				{
					for (i = 12; i >= 1; i += -2)
					{
						checksum = checksum + Convert.ToInt32(chaine.Substring(i - 1, 1));
					}

					checksum = checksum * 3;
					for (i = 11; i >= 1; i += -2)
					{
						checksum = checksum + Convert.ToInt32(chaine.Substring(i - 1, 1));
					}

					chaine = chaine + (10 - checksum % 10) % 10;
					CodeBarre = chaine.Substring(0, 1) + Convert.ToChar(65 + Convert.ToInt32((chaine.Substring(1, 1))));
					first = Convert.ToInt32(chaine.Substring(0, 1));
					for (i = 3; i <= 7; i++)
					{
						tableA = false;

						switch (i)
						{
							case 3:
								switch (first)
								{
									case 0:
									case 1:
									case 2:
									case 3:
										tableA = true;
										break;
								}
								break;

							case 4:
								switch (first)
								{
									case 0:
									case 4:
									case 7:
									case 8:
										tableA = true;
										break;
								}
								break;

							case 5:
								switch (first)
								{
									case 0:
									case 1:
									case 4:
									case 5:
									case 9:
										tableA = true;
										break;
								}
								break;

							case 6:
								switch (first)
								{
									case 0:
									case 2:
									case 5:
									case 6:
									case 7:
										tableA = true;
										break;
								}
								break;

							case 7:
								switch (first)
								{
									case 0:
									case 3:
									case 6:
									case 8:
									case 9:
										tableA = true;
										break;
								}
								break;
						}

						if (tableA)
						{
							CodeBarre = CodeBarre + Convert.ToChar(65 + Convert.ToInt32(chaine.Substring(i - 1, 1)));
						}
						else
						{
							CodeBarre = CodeBarre + Convert.ToChar(75 + Convert.ToInt32(chaine.Substring(i - 1, 1)));
						}
					}

					CodeBarre = CodeBarre + "*";
					for (i = 8; i <= 13; i++)
					{
						CodeBarre = CodeBarre + Convert.ToChar(97 + Convert.ToInt32(chaine.Substring(i - 1, 1)));
					}

					CodeBarre = CodeBarre + "+";
					functionReturnValue = CodeBarre;
				}
			}

			return functionReturnValue;
		}
	}
}
