const data = {
    name: 'Real Name',
    address: '',
    email: 'example@host.com',
    phone: '010-000-0000',
    dateAssigned: "2010-01-01",
}

function check_data_quality(data) {
    const comment = [];
    if (!data.name) comment.push("No name");
    if (!data.address) comment.push("No address");
    if (!data.email) comment.push("No Email");
    if (!data.phone) comment.push("No phone");
    const isOldData = new Date(data.dateAssigned) < new Date('2020-01-01');
    if (isOldData) comment.push("This data is old enough.");
    
    return comment.length > 0 ? comment : ['This is clean data.'];
}

console.log(check_data_quality(data));