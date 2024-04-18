(()=>{
    const apiRegister = 'http://localhost:5153/api/v1/admin/Register';
    const apiGetByUsername = 'http://localhost:5153/api/v1/adminstrator';
    let buttonSave = document.querySelector('.upsert-form button.insert');
    let buttonEdit = document.querySelectorAll('.data .button.edit');

    document.querySelector('a.create-button').addEventListener('click', event =>{
        document.querySelector('.modal-layer').style.display="flex";
        document.querySelector('.upsert-form button.update').style.display="none";
    })

    document.querySelector('.upsert-form button.cancle').addEventListener('click',() =>{
        document.querySelector('.modal-layer').style.display="none";
    })

    let admin = () =>{
        let form = document.querySelector('.upsert-form');
        let username = form.querySelector('[name="username"]');
        let jobTittle = form.querySelector('[name="jobtittle"]')
        console.log(username.value)
        console.log(jobTittle.value)
        addAdminAction({username: username.value, jobTitle: jobTittle.value});
    }

    let addAdminAction = (body) =>{
        let request = new XMLHttpRequest();
        request.open('POST', apiRegister);
        request.setRequestHeader('Content-type', 'application/json', 'charset-UTF-8');
        request.send(JSON.stringify(body));
        request.onload = () =>{
            if(request.status===200){
                alert("Admin Success Registered");
                document.querySelector('.modal-layer').style.display="none"
            }else{
                alert("Admin failed Registered");
                document.querySelector('.modal-layer').style.display="none"
            }
        }
    }

    buttonSave.addEventListener('click', (event)=>{
        event.preventDefault();
        admin();
    })

    for(let index=0; index<buttonEdit.length; index++){
        buttonEdit[index].addEventListener('click', (event)=>{
            let adminUsername = event.target.getAttribute('username');
            // console.log(adminUsername);
            getdataAdmin(adminUsername);
        })
    }

    let getdataAdmin = (username)=>{
        let request = new XMLHttpRequest();
        request.open('GET', `${apiGetByUsername}?username=${username}`);
        request.send();
        request.onload = () =>{
            const response = JSON.parse(request.response);
            bindingAdmin(response);
        }
    }

    let bindingAdmin = (admin)=>{
        document.querySelector('.modal-layer').style.display="flex";
        document.querySelector('.upsert-form button.insert').style.display="none";
        document.querySelector('.upsert-form h3').innerHTML = "Edit Admin"
        let form = document.querySelector('.upsert-form');
        form.querySelector('[name="username"]').value = admin.username
        form.querySelector('[name="jobtittle"]').value = admin.jobTitle
        form.querySelector('[name="password"]').value = admin.password
    }

    let buttonUpdate = document.querySelector('.upsert-form button.update');

    console.log(buttonUpdate);

    buttonUpdate.addEventListener('click', event =>{
        event.preventDefault();
        processedit();
        console.log(newAdmin());
    })

    let newAdmin = () =>{
        let form = document.querySelector('.upsert-form');
        let newusername = form.querySelector('[name="username"]').value;
        let newrole = form.querySelector('[name="jobtittle"]').value;
        let pass = form.querySelector('[name="password"]').value;
        console.log(`Username: ${newrole}`)
        return({username: newusername, jobTitle:newrole, password:pass});
    }

    let processedit = ()=>{
        let request = new XMLHttpRequest();
        request.open('PUT', apiGetByUsername);
        request.setRequestHeader('Content-type', 'application/json');
        request.send(JSON.stringify(newAdmin()));
        request.onload = () =>{
            if(request.status===200){
                alert("Updated Done")
                document.querySelector('.modal-layer').style.display="none";
                location.reload()
            }
            else{
                alert("Updated Failed");
                document.querySelector('.modal-layer').style.display="none";
                location.reload();
            }
        }
    }

})();