(()=>{

    let costpermalam = document.querySelector('.cost');
    let checkIn = document.querySelector('input.checkIn');
    let checkOut = document.querySelector('input.checkOut');

    if(checkIn != "" && checkOut !=""){
        document.querySelector('.bookDate').addEventListener('change', ()=>{
            let cost = (checkOut.value - checkIn.value) * costpermalam.textContent;
            document.querySelector('.costhotel').value = cost;
        })
    }
    // checkOut.onchange = ()=>{
    //     let cost = (checkOut.value - checkIn.value) * 
    // }
})();