Kata pour calculer la date d'invitation par rapport à l'éligibilité à un type de depistage, une date de naissance et la date du jour.
La date d'invitation correspond au jour de naissance du mois de naissance auquel on ajoute le nombre de mois associé au type de depistage et de l'année courante.
Il faut vérifier que la date d'invitation est bien valide, sinon on décale au jour ouvré valide.
Si la date d'invitation est antérieure à la date du jour, on ajoute un an à l'année courante.
Si la date d'invitation est un jour férié, on la décale au jour ouvré suivant.
Si la date d'invitation est un samedi ou un dimanche, on la décale au lundi suivant.

## Exemples
Date de naissance : 25/08/1993
Date du jour : 23/05/2023
Pour le dépistage de l'utérus, le nombre de mois est 2
alors la date d'invitation est le 25/10/2023

Date de naissance : 25/08/1993
Date du jour : 23/05/2023
Pour le dépistage du colon, le nombre de mois est 6
alors la date d'invitation est le 25/02/2024

Date de naissance : 25/03/1993
Date du jour : 23/05/2023
Pour le dépistage de l'utérus, le nombre de mois est 2
alors la date d'invitation est le 25/05/2023

Date de naissance : 31/08/1993
Date du jour : 23/05/2023
Pour le dépistage de l'utérus, le nombre de mois est 2
alors la date d'invitation est le 31/10/2023

Date de naissance : 31/03/1993
Date du jour : 23/05/2023
Pour le dépistage des poumons, le nombre de mois est 3
alors la date d'invitation est le 30/06/2023

Date de naissance : 30/11/1993
Date du jour : 23/05/2023
Pour le dépistage des poumons, le nombre de mois est 3
alors la date d'invitation est le 28/02/2023

