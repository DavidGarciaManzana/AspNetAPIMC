const url = "https://localhost:7033/api/item";
const url2 = "https://localhost:7033/api/create/createdb"
const shoppingList = document.getElementById("shoppingList")
const nameInput = document.getElementById("name")
const quantityInput = document.getElementById("quantity")
const addItemButton = document.getElementById("add-item")
// --------------------------------------------------------------------
const markItemAsBought = () => {
    let elements = Array.from(document.querySelectorAll(".container"))
    for (let i = 0; i < elements.length; i++) {
        let mark = (e) => {
            e.preventDefault()
            if (elements[i].classList.contains("Bought")) {
                elements[i].classList.remove("Bought")
                fetch(`${url}/${i + 1}`, {
                    method: 'PUT',
                    mode: 'cors',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        "state": "Pending"
                    })
                });
            } else {
                elements[i].classList.add("Bought")
                elements[i].classList.remove("Pending")
                fetch(`${url}/${i + 1}`, {
                    method: 'PUT',
                    mode: 'cors',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify({
                        "state": "Bought"
                    })
                });
            }
        }
        elements[i].addEventListener("click", mark)
    }
}
const drawDataFromDBInShoppingList = () => {
    fetch(url, {method: "GET"})
        .then(resp => resp.json())
        .then(data => {
            data.forEach(item => {
                let itemName = document.createElement("label")
                itemName.classList.add("container", `${item.state}`)
                itemName.innerHTML = `
                <span>${item.name}</span>
                <span class="amount">${item.quantity}</span>`
                shoppingList.appendChild(itemName)
            })
        })
        .then(markItemAsBought)
}
const eraseDataInShoppingList = () => {
    shoppingList.innerHTML = ''
}
const updateBD = async () => {
    if (nameInput.value === "" || quantityInput.value === "") {
        return window.alert("You must provide both item name and quantity")
    } else {
        fetch(url, {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                "name": `${nameInput.value}`,
                "quantity": `${quantityInput.value}`
            })
        })
            .then(() => {
                eraseDataInShoppingList();
                drawDataFromDBInShoppingList();
                location.reload()
            })
    }
}
// --------------------------------------------------------------------
fetch(url2, {
    method: 'GET', // *GET, POST, PUT, DELETE, etc.
    mode: 'no-cors', // no-cors, *cors, same-origin
    headers: {
        'Content-Type': 'application/json'
    }
});
drawDataFromDBInShoppingList();
addItemButton.addEventListener("click", updateBD);