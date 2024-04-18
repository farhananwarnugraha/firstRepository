(()=>{
    const url = 'http://localhost:5153/api/v1/roomservice';
    let buttonEdit = document.querySelectorAll('.data a.button.edit');

    document.querySelector('a.create-button').addEventListener('click', () =>{
        document.querySelector('.modal-layer').style.display="flex";
        document.querySelector('.upsert-form button.update').style.display="none";
    });

    document.querySelector('.upsert-form button.cancle').addEventListener('click', () =>{
        document.querySelector('.modal-layer').style.display="none";
    })
    let newEmployee = ()=>{
        let employeenumber = document.querySelector('.upsert-form input[name="number"]');
        let firstname = document.querySelector('.upsert-form input[name="firstName"]');
        let middlename = document.querySelector('.upsert-form input[name="middleName"]');
        let lastname = document.querySelector('.upsert-form input[name="lastName"]');
        let outsourcing = document.querySelector('.upsert-form input[name="outsourcingCompany"]');
        addNewEmployee({employeeNumber: employeenumber.value, firstName: firstname.value, middleName: middlename.value,lastName:lastname.value ,outsourcingCompany:outsourcing.value});
    }

    let addNewEmployee = (body) =>{
        let request = new XMLHttpRequest();
        request.open('POST', url);
        request.setRequestHeader('Content-type', 'application/json', 'charset-UTF-8');
        request.send(JSON.stringify(body));
        request.onload = () =>{
            if(request.status === 200){
                alert("Employee has been Inputed");
                document.querySelector('.modal-layer').style.display="none"
                location.reload();
            }
            else{
                alert("Employee failed Inputed");
                document.querySelector('.modal-layer').style.display="none";
            }
        }
    }

    document.querySelector('.upsert-form').addEventListener('submit', (event) =>{
        event.preventDefault();
        newEmployee();
    })

    for(let index=0; index<buttonEdit.length; index++){
        buttonEdit[index].addEventListener('click', event=>{
            let employeeNumber = event.target.getAttribute('employeeNumber');
            getEmployee(employeeNumber);
        })
    }

    let getEmployee = (number) =>{
        let request = new XMLHttpRequest();
        request.open('GET', `${url}?employeeNumber=${number}`);
        request.send();
        request.onload = () =>{
            const respon = JSON.parse(request.response);
            request.status === 200? bindingEmployee(respon) : console.log("Data Not Found");
        }
    }

    let bindingEmployee = (employee) =>{
        document.querySelector('.modal-layer').style.display="flex";
        document.querySelector('.upsert-form button.insert').style.display="none";
        document.querySelector('.upsert-form h3').innerHTML="Update Employee";
        document.querySelector('.upsert-form input[name="number"]').value = employee.employeeNumber;
        document.querySelector('.upsert-form input[name="firstName"]').value = employee.firstName;
        document.querySelector('.upsert-form input[name="middleName"]').value = employee.middleName;
        document.querySelector('.upsert-form input[name="lastName"]').value = employee.lastName;
        document.querySelector('.upsert-form input[name="outsourcingCompany"]').value = employee.outsourcingCompany;
        document.querySelector('.upsert-form input[name="number"]').setAttribute("disabled", true)
    }

    document.querySelector('.upsert-form').addEventListener('submit', event =>{
        event.preventDefault();
        editacction();
    })

    let newdataemployee = () =>{
        let employeenumber = document.querySelector('.upsert-form input[name="number"]');
        let firstname = document.querySelector('.upsert-form input[name="firstName"]');
        let middlename = document.querySelector('.upsert-form input[name="middleName"]');
        let lastname = document.querySelector('.upsert-form input[name="lastName"]');
        let outsourcing = document.querySelector('.upsert-form input[name="outsourcingCompany"]');
        return ({employeeNumber: employeenumber.value, firstName: firstname.value, middleName: middlename.value,lastName:lastname.value ,outsourcingCompany:outsourcing.value});
    }

    let editacction = () =>{
        let request = new XMLHttpRequest();
        request.open('PUT', url);
        request.setRequestHeader('Content-type', 'application/json');
        request.send(JSON.stringify(newdataemployee()));
        request.onload = () =>{
            if(request.status === 200){
                alert("Employee has been updated");
                document.querySelector('.modal-layer').style.display="none";
                location.reload();
            }else{
                alert("Employee failed update");
                document.querySelector('.modal-layer').style.display="none";
            }
        }
    }


})();