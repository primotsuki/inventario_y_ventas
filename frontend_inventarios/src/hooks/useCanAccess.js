const roles = {
    director: 1,
    pasajes: 2,
    planificacion: 3,
    presupuestos: 4,
    sysadmin:5
}
const useCanAccess = () => {
    const user = JSON.parse(localStorage.getItem('userInfo'));
    const menuPermission = {
        users: user.roleId == roles.sysadmin || user.roleId == roles.pasajes,
        pasajes: user.roleId == roles.pasajes,
        designacion: user.roleId == roles.director,
        presupuestos: user.roleId == roles.presupuestos,
        planificacion: user.roleId == roles.planificacion
    };
    return [menuPermission];
}

export default useCanAccess;