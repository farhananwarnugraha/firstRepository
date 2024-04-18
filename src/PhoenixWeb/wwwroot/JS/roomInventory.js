(()=>{
    const url = 'http://localhost:5153/api/v1/roominventory';
    const params = 'roomNumber'
    let buttonAdd = document.querySelector('a.create-button');
    let buttonSave = document.querySelector('button.insert');
    let buttonCancle = document.querySelector('button.cancle');
    let buttonRemove = document.querySelectorAll('.data a.button.delete');
    buttonAdd.addEventListener('click', event =>{
        let roomNumber = event.target.getAttribute('roomNumber')
        document.querySelector('.modal-layer').style.display="flex";
        document.querySelector('.upsert-form button.update').style.display="none";
        console.log(roomNumber);
        getRoomInventory(roomNumber);
    })

    let getRoomInventory = (roomNumber) =>{
        let request = new XMLHttpRequest();
        request.open('GET', `${url}?${params}=${roomNumber}`);
        request.send();
        request.onload = () =>{
            const response = JSON.parse(request.response);
            console.log(response);
            addRoomInventory(response);
        }
    }


    let addRoomInventory = (respons) =>{
        let roomNumber = respons.roomNumber;
        let formRoom = document.querySelector('form.upsert-form input[name="roomNumber"]');
        formRoom.value = roomNumber;
        let select = document.querySelector('form.upsert-form select');
        let optionSelected = document.createElement('option');
        optionSelected.setAttribute('value', " ");
        optionSelected.textContent="Pilih Barang";
        select.append(optionSelected);
        for(const inventory of respons.inventoryNames){
            let selectionOption = document.createElement('option');
            selectionOption.setAttribute('value', inventory.name);
            selectionOption.textContent=inventory.name;
            select.append(selectionOption);
        }
    }

    let addRoomInventories = () =>{
        let rooms = document.querySelector('form.upsert-form input[name="roomNumber"]');
        let inventoryName = document.querySelector('form.upsert-form select');
        let quantityInventory = document.querySelector('form.upsert-form input[name="stock"]');
        addAction({roomNumber: rooms.value, InventoryName: inventoryName.value, Quantity: quantityInventory.value});
    }

    let addAction =(body)=>{
        // console.log(addRoomInventories())
        let request = new XMLHttpRequest();
        request.open('POST', url);
        request.setRequestHeader('Content-type', 'application/json', 'charset-UTF-8');
        request.send(JSON.stringify(body));
        request.onload = () =>{
            if(request.status === 200){
                alert('Succes add Inventory');
                document.querySelector('.modal-layer').style.display="none";
                location.reload();
            }else{
                alert('Inventory failed inputed');
                document.querySelector('.modal-layer').style.display="none";
            }
        }
    }

    buttonSave.addEventListener('click', event =>{
        event.preventDefault();
        addRoomInventories();
    });

    buttonCancle.addEventListener('click', () =>{
        document.querySelector('.modal-layer').style.display="none";
    })

    for(let index=0; index<buttonRemove.length; index++){
        buttonRemove[index].addEventListener('click', event =>{
            let inventoryName = event.target.getAttribute('nameInventory');
            document.querySelector('.modal-layer.confirmation-delete').style.display="flex";
            document.querySelector('.yes-button').addEventListener('click', event =>{
                deleteInventory(inventoryName);
            })

            document.querySelector('.no-button').addEventListener('click', ()=>{
                document.querySelector('.modal-layer.confirmation-delete').style.display="none";
            })
        })
    }

    let deleteInventory = (idInventory) =>{
        let request = new XMLHttpRequest();
        request.open('DELETE', `${url}?idInventory=${idInventory}`);
        request.send();
        request.onload = () =>{
            if(request.status === 200){
                alert("Deleted Successed");
                document.querySelector('.modal-layer.confirmation-delete').style.display="none";
                location.reload();
            }
            else{
                alert("Deleted Failed")
                document.querySelector('.modal-layer.confirmation-delete').style.display="none";
            }
        }
    }

})();