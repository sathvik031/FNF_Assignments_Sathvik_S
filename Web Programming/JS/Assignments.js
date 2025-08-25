function signIn(username, password) {
    if (!username || !password) return false;

    const storedPassword = localStorage.getItem(username);
    if (!storedPassword || storedPassword !== password) return false;

    try {
        let activeUsers = localStorage.getItem("ActiveUsers");
        activeUsers = activeUsers ? JSON.parse(activeUsers) : [];

        // Check if user is already active
        const isAlreadyActive = activeUsers.some(user => user.hasOwnProperty(username));
        if (!isAlreadyActive) {
            activeUsers.push({ [username]: password });
            localStorage.setItem("ActiveUsers", JSON.stringify(activeUsers));
        }
    } catch (err) {
        console.error("Error updating ActiveUsers:", err);
        return false;
    }

    return true;
}

function signUp(username, password) {
    if (!username || !password) return false;

    if (localStorage.getItem(username)) {
        return false; // Username already exists
    }
    localStorage.setItem(username, password);

    let allUsers = localStorage.getItem("AllUsers");
    allUsers = allUsers ? JSON.parse(allUsers) : [];
    allUsers.push({ [username]: password });
    localStorage.setItem("AllUsers", JSON.stringify(allUsers));
    console.log(allUsers);
    return true;
}
