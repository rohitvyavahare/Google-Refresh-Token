// Google Importation stuff

var googleContacts = [];

window.onload = function () {

    var ele = document.getElementById("myInput");
    var choice =  ele.value;
    console.log(choice);
    
    if (choice.indexOf("Access_Token") > -1) {

        var ele2 = document.getElementById("glogin");
        ele2.style.visibility = 'hidden';;
        console.log(choice);
        var split = choice.split(":");
        console.log(split[1]);
        $.get("https://www.google.com/m8/feeds/contacts/default/full?alt=json&access_token=" +split[1] + "&max-results=11700&v=3.0",
            handleGoogleContacts);
    }
    
    }
  
function handleGoogleContacts(response) {
    if (response.feed.entry.length > 0) {
        for (var i = 0 ; i < response.feed.entry.length ; i++) {

            if (response.feed.entry[i].gd$email) {

                if (response.feed.entry[i].gd$email[0] != undefined) {

                    var tempEmail = response.feed.entry[i].gd$email[0].address;

                    if (response.feed.entry[i].gd$name != undefined) {

                        googleContacts.push({
                            "label": response.feed.entry[i].gd$name.gd$fullName.$t,
                            "value": tempEmail
                        });
                    }
                    else {
                        googleContacts.push({
                            "label": tempEmail,
                            "value": tempEmail
                        });
                    }
                }
            }
            else {
                continue;
            }
        }
        console.log( JSON.stringify(googleContacts));
    }
    else { alert("something went wrong ! your contact list is undefined"); }
}