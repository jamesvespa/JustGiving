My approach was as follows:

Story 1:
I created and unit tested the gift Aid calculator.

Story 2:
I created an Endpoint with just a GET and called giftaid from https://localhost:44320/api/giftaid
Note the Donation amount is passed as a param (5 in this case) https://localhost:44320/api/giftaid/5
I verified the GET using chrome - see giftaid.jpg

Story 3:
I had added validation in Story 1 and the remaining validation I added during Story 4. My checkin to Git consisted of tidyups.

Story 4:
I added a POST to the existing endpoint and used an in memory db to store the declarations.
I wrote a number of Endpoint unit tests and 'Faked' the context so I could test the controller (endpoint).
Note i also verified the POST using fiddler - see Declaration.jpg
