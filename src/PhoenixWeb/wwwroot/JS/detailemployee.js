(()=>{
    document.querySelector('.data-set .create-button').addEventListener('click', event =>{
        document.querySelector('.data-set').style.display="none";
        document.querySelector('.edit-roaster').style.display="block"
    })

    console.log(document.querySelector('.edit-roaster .create-button'));

    document.querySelector('.edit-roaster .create-button').addEventListener('click', () =>{
        document.querySelector('.data-set').style.display="block";
        document.querySelector('.edit-roaster').style.display="none"
    })
})()