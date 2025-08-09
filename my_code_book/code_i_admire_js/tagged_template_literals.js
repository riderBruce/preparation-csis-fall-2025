function tag(strings, ...value) {
  return strings.reduce((acc, string, i) => {
    return acc + string + (value[i] ? `<thisTag>${value[i]}</thisTag>` : "")
  }, "");
}
const name1 = "alex";
const lang = "javascript";
const feeling = "exciting";

const result = tag`This guy ${name1} study ${lang} and feel ${feeling}!`

console.log(result);