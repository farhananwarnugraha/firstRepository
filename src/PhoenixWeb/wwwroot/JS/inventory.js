(()=>{
    const apiInventory = 'http://localhost:5153/api/v1/Inventory';
    let params = 'name';
    let buttonAdd = document.querySelector('.create-button');
    let buttonCancle = document.querySelector('.upsert-form button.cancle');
    let buttonSave = document.querySelector('.upsert-form button.insert')
    let buttonedit = document.querySelectorAll('.data .button.edit');
    let buttonUpdate = document.querySelector('.upsert-form button.update');
    let buttonDelete = document.querySelectorAll('.data .button.delete');

    buttonAdd.addEventListener('click', event =>{
        document.querySelector('.modal-layer').style.display="flex";
        document.querySelector('.upsert-form button.update').style.display="none";
    })

    buttonCancle.addEventListener('click', event =>{
        document.querySelector('.modal-layer').style.display="none";
    })

    let getDataInventory = () =>{
        let form = document.querySelector('.upsert-form');
        let nameInventory = form.querySelector('[name="name"]');
        let stockInventory = form.querySelector('[name="stock"]');
        let descriptionInventory = form.querySelector('[name="description"');
        addAction({name: nameInventory.value, stock: stockInventory.value, description: descriptionInventory.value});
    }

    let addAction = (body) =>{
        let request = new XMLHttpRequest;
        request.open('POST', apiInventory);
        request.setRequestHeader('Content-type', 'application/json', 'charset-UTF-8');
        request.send(JSON.stringify(body));
        request.onload = ()=>{
            if(request.status === 200){
                alert("Inventory successfully added");
                document.querySelector('.modal-layer').style.display="none";
                location.reload(); 
            }
            else{
                alert("Inventory failed to be added");
                document.querySelector('.modal-layer');
            }
        }
    }

    buttonSave.addEventListener('click', event =>{
        getDataInventory();
    });

    for(let index=0; index<buttonedit.length; index++){
        buttonedit[index].addEventListener('click', event=>{
            let inventoryname = event.target.getAttribute('nameInventory');
            getInventory(inventoryname);
        })
    }

    let getInventory = (inventory) =>{
        let request = new XMLHttpRequest();
        request.open('GET', `${apiInventory}?${params}=${inventory}`);
        request.send();
        request.onload = ()=>{
            const response = JSON.parse(request.response);
            request.status === 200 ? bindingData(response) : console.log("Data Not Found");
        } 
    }

    let bindingData = (inventory)=>{
        document.querySelector('.modal-layer').style.display="flex";
        buttonSave.style.display="none";
        document.querySelector('.upsert-form h3').innerHTML="Edit Inventory";
        document.querySelector('.upsert-form input[name="name"]').value = inventory.name;
        document.querySelector('.upsert-form input[name="stock"]').value = inventory.stock;
        document.querySelector('.upsert-form textarea[name="description"').value = inventory.description;
    }

    buttonUpdate.addEventListener('click', (event) =>{
        event.preventDefault();
        editProcess();
        console.log(dataInventory());
    })

    let dataInventory = () =>{
        let nameInventory = document.querySelector('.upsert-form input[name="name"]').value;
        let stockInventory = document.querySelector('.upsert-form input[name="stock"]').value;
        let description = document.querySelector('.upsert-form textarea[name="description"').value;
        return ({name: nameInventory, stock: stockInventory, description: description});
    }

    let editProcess = ()=>{
        let request = new XMLHttpRequest();
        request.open('PUT', apiInventory);
        request.setRequestHeader('Content-type', 'application/json');
        request.send(JSON.stringify(dataInventory()));
        request.onload = () =>{
            // const response = JSON.parse(request.response);
            if(request.status === 200){
                alert("Inventory has been updated");
                document.querySelector('.modal-layer').style.display="none";
                location.reload();
            }else{
                alert("Inventory failed update");
                document.querySelector('.modal-layer').style.display="none";
            }
        }
    }

    for(let index=0; index<buttonDelete.length; index++){
        buttonDelete[index].addEventListener('click', event=>{
            let inventoryname = event.target.getAttribute('nameInventory');
            document.querySelector('.modal-layer.confirmation-delete').style.display="flex"
            document.querySelector('.yes-button').addEventListener('click', ()=>{
                deleteInventory(inventoryname);
            })
            document.querySelector('.no-button').addEventListener('click', ()=>{
                document.querySelector('.modal-layer.confirmation-delete').style.display="none"
            })
        })
    }

    let deleteInventory = (inventory) =>{
        let request = new XMLHttpRequest();
        request.open('DELETE', `${apiInventory}?${params}=${inventory}`);
        request.send();
        request.onload = () =>{
            if(request.status===200){
                alert("Inventory Has Been Deleted")
                document.querySelector('.modal-layer.confirmation-delete').style.display="none"
                location.reload();
            }
            else{
                alert("Inventory failed to be deleted")
                document.querySelector('.modal-layer.confirmation-delete').style.display="none"
            }
        }
    }

   
})();