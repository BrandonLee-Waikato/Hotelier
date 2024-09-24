function onSignIn(googleUser) {
    var profile = googleUser.getBasicProfile();
    console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
    console.log('Name: ' + profile.getName());
    console.log('Image URL: ' + profile.getImageUrl());
    console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
}


    var counter = 1;
    setInterval(function(){
        document.getElementById('r' + counter).checked = true;
    counter++;
        if(counter > 5){
        counter = 1;
        }
    }, 2500); // 500毫秒 = 0.5秒
