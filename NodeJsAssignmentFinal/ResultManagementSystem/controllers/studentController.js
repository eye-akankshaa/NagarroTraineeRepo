const Student = require("../model/student");

const student_login_get = (req, res) => {
  res.render("student/studentlogin");
};

const student_login_post = async (req, res) => {
  const Sturoll = req.body.roll;
  const Stuname = req.body.name;
  const individualStudent = await Student.findOne({
    roll: Sturoll,
    name: Stuname,
  });
  if (!individualStudent) {
    res.render("student/studentlogin", {
      error: "Login with correct roll number",
    });
  }
  res.render("student/studentview", { one: individualStudent });
};

module.exports = {
  student_login_get,
  student_login_post,
};
